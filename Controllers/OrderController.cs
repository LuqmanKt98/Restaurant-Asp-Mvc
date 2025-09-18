using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebRestoran.Data;
using WebRestoran.Models;
using System.Linq;


namespace WebRestoran.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepo<Order> _orderRepo;
        private readonly IRepo<OrderItem> _orderItemRepo;
        private readonly IRepo<Food> _foodRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(
            IRepo<Order> orderRepo,
            IRepo<OrderItem> orderItemRepo,
            IRepo<Food> foodRepo,
            IWebHostEnvironment webHostEnvironment,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
            _foodRepo = foodRepo;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _userManager = userManager;
        }
       
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Redirect to Food/Index for ordering instead of showing Create view
            TempData["Info"] = "Please select items from our menu to place your order.";
            return RedirectToAction("Index", "Food");
        }

        public IActionResult Index()
        {
            return View();
        }
       

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddItem(int FoodId, int Quantity, string returnUrl = null)
        {
            var product = await _context.Food.FindAsync(FoodId);
            if (product == null)
            {
                return NotFound();
            }

            // Normalize and enforce stock limits
            if (Quantity < 1) Quantity = 1;
            if (product.Stock > 0 && Quantity > product.Stock)
            {
                Quantity = product.Stock;
            }

            if (product.Stock <= 0)
            {
                TempData["Error"] = $"{product.FoodName} is currently out of stock.";
                // Redirect back to menu if came from there, otherwise to Create
                var referer = Request.Headers["Referer"].ToString();
                if (referer.Contains("/Food/Index"))
                {
                    return RedirectToAction("Index", "Food");
                }
                return RedirectToAction("Create");
            }

            // Create order directly
            var userId = _userManager.GetUserId(User);
            var order = new Order
            {
                OrderDate = DateTime.Now,
                UserId = userId,
                TotalAmount = product.Price * Quantity,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        FoodId = product.FoodId,
                        Quantity = Quantity,
                        Price = product.Price
                    }
                }
            };

            // Deduct stock
            product.Stock -= Quantity;
            await _orderRepo.AddAsync(order);

            TempData["Success"] = $"Order placed successfully! {Quantity}x {product.FoodName} ordered.";
            
            // Redirect back to menu if came from there, otherwise to Create
            var refererHeader = Request.Headers["Referer"].ToString();
            if (refererHeader.Contains("/Food/Index"))
            {
                return RedirectToAction("Index", "Food");
            }
            return RedirectToAction("Create");
        }


        // Cart functionality removed - using direct ordering instead

        // PlaceOrder method removed - using direct ordering through AddItem instead

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> ViewOrders()
        {
            if (User.IsInRole("Admin"))
            {
                var allOrders = await _orderRepo.GetAllOrdersWithItemsAsync();
                return View(allOrders);
            }

            var currentUserId = _userManager.GetUserId(User);
            var all = await _orderRepo.GetAllOrdersWithItemsAsync();
            var myOrders = all.Where(o => o.UserId == currentUserId).ToList();
            return View(myOrders);
        }

        // Cart-related methods removed - using direct ordering system instead
    }
}
