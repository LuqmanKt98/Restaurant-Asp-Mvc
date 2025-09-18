using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebRestoran.Models;
using WebRestoran.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebRestoran.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IRepo<Order> _orderRepo;
        private readonly IRepo<Food> _foodRepo;
        private readonly IRepo<Ingredient> _ingredientRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IRepo<Order> orderRepo, IRepo<Food> foodRepo, IRepo<Ingredient> ingredientRepo, 
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _orderRepo = orderRepo;
            _foodRepo = foodRepo;
            _ingredientRepo = ingredientRepo;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepo.GetAllOrdersWithItemsAsync();
            var ingredients = await _ingredientRepo.GetAllAsync();
            var foods = await _foodRepo.GetAllAsync();
            var users = _userManager.Users.ToList();
            
            var now = DateTime.Now;
            var today = now.Date;
            var weekStart = today.AddDays(-(int)today.DayOfWeek);
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var yearStart = new DateTime(today.Year, 1, 1);
            var lastMonthStart = monthStart.AddMonths(-1);
            var lastMonthEnd = monthStart.AddDays(-1);
            
            // Basic Statistics
            var totalOrders = orders.Count();
            var totalRevenue = orders.Sum(o => o.TotalAmount);
            var totalFoods = foods.Count();
            var totalIngredients = ingredients.Count();
            var totalUsers = users.Count();
            
            // Revenue Analytics
            var todayRevenue = orders.Where(o => o.OrderDate.Date == today).Sum(o => o.TotalAmount);
            var weekRevenue = orders.Where(o => o.OrderDate.Date >= weekStart).Sum(o => o.TotalAmount);
            var monthRevenue = orders.Where(o => o.OrderDate.Date >= monthStart).Sum(o => o.TotalAmount);
            var yearRevenue = orders.Where(o => o.OrderDate.Date >= yearStart).Sum(o => o.TotalAmount);
            
            // Order Analytics
            var todayOrders = orders.Count(o => o.OrderDate.Date == today);
            var weekOrders = orders.Count(o => o.OrderDate.Date >= weekStart);
            var monthOrders = orders.Count(o => o.OrderDate.Date >= monthStart);
            var pendingOrders = orders.Count(o => o.Status == OrderStatus.Pending);
            var processingOrders = orders.Count(o => o.Status == OrderStatus.Processing);
            var completedOrders = orders.Count(o => o.Status == OrderStatus.Completed);
            var cancelledOrders = orders.Count(o => o.Status == OrderStatus.Cancelled);
            
            // Performance Metrics
            var averageOrderValue = totalOrders > 0 ? totalRevenue / totalOrders : 0;
            var revenuePerUser = totalUsers > 0 ? totalRevenue / totalUsers : 0;
            var ordersPerUser = totalUsers > 0 ? (decimal)totalOrders / totalUsers : 0;
            
            // Growth Calculations
            var lastMonthRevenue = orders.Where(o => o.OrderDate.Date >= lastMonthStart && o.OrderDate.Date <= lastMonthEnd).Sum(o => o.TotalAmount);
            var lastMonthOrders = orders.Count(o => o.OrderDate.Date >= lastMonthStart && o.OrderDate.Date <= lastMonthEnd);
            var revenueGrowthPercentage = lastMonthRevenue > 0 ? ((monthRevenue - lastMonthRevenue) / lastMonthRevenue) * 100 : 0;
            var orderGrowthPercentage = lastMonthOrders > 0 ? ((decimal)(monthOrders - lastMonthOrders) / lastMonthOrders) * 100 : 0;
            
            // Inventory Insights
            var lowStockItems = ingredients.Count(i => i.IsLowStock);
            var outOfStockItems = ingredients.Count(i => i.CurrentStock == 0);
            var totalInventoryValue = ingredients.Sum(i => i.TotalValue);
            
            // Top Performing Items
            var topSellingFoods = orders
                .SelectMany(o => o.OrderItems)
                .GroupBy(oi => oi.Food.FoodName)
                .Select(g => new TopPerformingItem
                {
                    Name = g.Key,
                    OrderCount = g.Sum(oi => oi.Quantity),
                    Revenue = g.Sum(oi => oi.Quantity * oi.Price)
                })
                .OrderByDescending(x => x.Revenue)
                .Take(5)
                .ToList();
            
            // Recent Orders
            var recentOrders = orders
                .OrderByDescending(o => o.OrderDate)
                .Take(10)
                .Select(o => new RecentOrderSummary
                {
                    OrderId = o.OrderId,
                    CustomerName = o.User?.UserName ?? "Guest",
                    TotalAmount = o.TotalAmount,
                    OrderDate = o.OrderDate,
                    Status = o.StatusDisplayName
                })
                .ToList();

            var model = new AdminDashboardViewModel
            {
                // Basic Statistics
                TotalOrders = totalOrders,
                TotalRevenue = totalRevenue,
                TotalFoods = totalFoods,
                TotalIngredients = totalIngredients,
                TotalUsers = totalUsers,
                
                // Revenue Analytics
                TodayRevenue = todayRevenue,
                WeekRevenue = weekRevenue,
                MonthRevenue = monthRevenue,
                YearRevenue = yearRevenue,
                
                // Order Analytics
                TodayOrders = todayOrders,
                WeekOrders = weekOrders,
                MonthOrders = monthOrders,
                PendingOrders = pendingOrders,
                ProcessingOrders = processingOrders,
                CompletedOrders = completedOrders,
                CancelledOrders = cancelledOrders,
                
                // Performance Metrics
                AverageOrderValue = averageOrderValue,
                RevenuePerUser = revenuePerUser,
                OrdersPerUser = ordersPerUser,
                RevenueGrowthPercentage = revenueGrowthPercentage,
                OrderGrowthPercentage = orderGrowthPercentage,
                
                // Inventory Insights
                LowStockItems = lowStockItems,
                OutOfStockItems = outOfStockItems,
                TotalInventoryValue = totalInventoryValue,
                
                // Top Performing Items
                TopSellingFoods = topSellingFoods,
                RecentOrders = recentOrders
            };
            return View(model);
        }

        // User Management
        public async Task<IActionResult> Users(string searchTerm = "", string roleFilter = "")
        {
            var users = _userManager.Users.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(u => u.Email.Contains(searchTerm) || u.UserName.Contains(searchTerm));
            }

            var userList = await users.ToListAsync();
            var userViewModels = new List<UserManagementViewModel>();

            foreach (var user in userList)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var orders = await _orderRepo.GetAllOrdersWithItemsAsync();
                var userOrders = orders.Where(o => o.UserId == user.Id).ToList();

                if (!string.IsNullOrEmpty(roleFilter) && !roles.Contains(roleFilter))
                    continue;

                userViewModels.Add(new UserManagementViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    EmailConfirmed = user.EmailConfirmed,
                    LockoutEnd = user.LockoutEnd,
                    Roles = roles.ToList(),
                    TotalOrders = userOrders.Count,
                    TotalSpent = userOrders.Sum(o => o.TotalAmount),
                    LastOrderDate = userOrders.OrderByDescending(o => o.OrderDate).FirstOrDefault()?.OrderDate
                });
            }

            ViewBag.SearchTerm = searchTerm;
            ViewBag.RoleFilter = roleFilter;
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            return View(userViewModels);
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var roles = await _userManager.GetRolesAsync(user);
            var orders = await _orderRepo.GetAllOrdersWithItemsAsync();
            var userOrders = orders.Where(o => o.UserId == user.Id).OrderByDescending(o => o.OrderDate).ToList();

            var model = new UserDetailsViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                LockoutEnd = user.LockoutEnd,
                AccessFailedCount = user.AccessFailedCount,
                Roles = roles.ToList(),
                Orders = userOrders,
                TotalOrders = userOrders.Count,
                TotalSpent = userOrders.Sum(o => o.TotalAmount)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleUserLockout(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.Now)
            {
                await _userManager.SetLockoutEndDateAsync(user, null);
            }
            else
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now.AddYears(100));
            }

            return RedirectToAction(nameof(UserDetails), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserRole(string userId, string role, bool assign)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            if (assign)
            {
                if (!await _userManager.IsInRoleAsync(user, role))
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }
            else
            {
                if (await _userManager.IsInRoleAsync(user, role))
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
            }

            return RedirectToAction(nameof(UserDetails), new { id = userId });
        }

        // Inventory Management Methods
        public async Task<IActionResult> Inventory()
        {
            var ingredients = await _ingredientRepo.GetAllAsync();
            var lowStockIngredients = ingredients.Where(i => i.IsLowStock).ToList();
            
            ViewBag.LowStockCount = lowStockIngredients.Count;
            ViewBag.TotalValue = ingredients.Sum(i => i.TotalValue);
            
            return View(ingredients);
        }

        public async Task<IActionResult> InventoryDetails(int id)
        {
            var options = new QueryOptions<Ingredient>();
            var ingredient = await _ingredientRepo.GetByIdAsync(id, options);
            if (ingredient == null)
                return NotFound();

            return View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStock(int id, decimal newStock, string? notes = null)
        {
            var options = new QueryOptions<Ingredient>();
            var ingredient = await _ingredientRepo.GetByIdAsync(id, options);
            if (ingredient == null)
                return NotFound();

            ingredient.CurrentStock = newStock;
            ingredient.LastRestocked = DateTime.Now;
            ingredient.UpdatedDate = DateTime.Now;

            await _ingredientRepo.UpdateAsync(ingredient);
            
            TempData["SuccessMessage"] = $"Stock updated for {ingredient.IngredientName}";
            return RedirectToAction("InventoryDetails", new { id });
        }

        public async Task<IActionResult> LowStockAlerts()
        {
            var ingredients = await _ingredientRepo.GetAllAsync();
            var lowStockIngredients = ingredients.Where(i => i.IsLowStock).ToList();
            
            return View(lowStockIngredients);
        }

        // Menu Management Methods
        public async Task<IActionResult> MenuManagement()
        {
            var foods = await _foodRepo.GetAllAsync();
            var categories = foods.GroupBy(f => f.Category?.CategoryName ?? "Uncategorized")
                                 .Select(g => new { Category = g.Key, Count = g.Count() })
                                 .ToList();
            
            ViewBag.TotalItems = foods.Count();
            ViewBag.LowStockItems = foods.Count(f => f.Stock <= 5);
            ViewBag.OutOfStockItems = foods.Count(f => f.Stock == 0);
            ViewBag.Categories = categories;
            
            return View(foods);
        }

        // Order Status Management
        public async Task<IActionResult> Orders(string status = "all")
        {
            var orders = await _orderRepo.GetAllOrdersWithItemsAsync();
            
            if (status != "all")
            {
                if (Enum.TryParse<OrderStatus>(status, true, out var orderStatus))
                {
                    orders = orders.Where(o => o.Status == orderStatus).ToList();
                }
            }
            
            ViewBag.CurrentFilter = status;
            ViewBag.PendingCount = orders.Count(o => o.Status == OrderStatus.Pending);
            ViewBag.ProcessingCount = orders.Count(o => o.Status == OrderStatus.Processing);
            ViewBag.CompletedCount = orders.Count(o => o.Status == OrderStatus.Completed);
            ViewBag.CancelledCount = orders.Count(o => o.Status == OrderStatus.Cancelled);
            
            return View(orders);
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            var options = new QueryOptions<Order>();
            var order = await _orderRepo.GetByIdAsync(id, options);
            
            if (order == null)
            {
                return NotFound();
            }
            
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, OrderStatus newStatus, string? notes = null)
        {
            var options = new QueryOptions<Order>();
            var order = await _orderRepo.GetByIdAsync(orderId, options);
            
            if (order == null)
            {
                TempData["Error"] = "Order not found.";
                return RedirectToAction("Orders");
            }
            
            // Validate status transition
            if (!IsValidStatusTransition(order.Status, newStatus))
            {
                TempData["Error"] = $"Cannot change status from {order.Status} to {newStatus}.";
                return RedirectToAction("OrderDetails", new { id = orderId });
            }
            
            order.Status = newStatus;
            order.UpdatedDate = DateTime.Now;
            order.StatusNotes = notes;
            
            if (newStatus == OrderStatus.Processing)
            {
                order.ProcessedBy = User.Identity?.Name ?? "Admin";
                order.EstimatedDeliveryTime = DateTime.Now.AddMinutes(30); // Default 30 minutes
            }
            
            await _orderRepo.UpdateAsync(order);
            
            TempData["Success"] = $"Order status updated to {newStatus}.";
            return RedirectToAction("OrderDetails", new { id = orderId });
        }
        
        private bool IsValidStatusTransition(OrderStatus currentStatus, OrderStatus newStatus)
        {
            return currentStatus switch
            {
                OrderStatus.Pending => newStatus == OrderStatus.Processing || newStatus == OrderStatus.Cancelled,
                OrderStatus.Processing => newStatus == OrderStatus.Completed || newStatus == OrderStatus.Cancelled,
                OrderStatus.Completed => false, // Cannot change from completed
                OrderStatus.Cancelled => false, // Cannot change from cancelled
                _ => false
            };
        }
    }
}