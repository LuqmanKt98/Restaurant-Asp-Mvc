using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRestoran.Models;
using WebRestoran.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace WebRestoran.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IRepo<Order> _orderRepo;
        private readonly IRepo<Food> _foodRepo;
        private readonly IRepo<Ingredient> _ingredientRepo;

        public AdminController(IRepo<Order> orderRepo, IRepo<Food> foodRepo, IRepo<Ingredient> ingredientRepo)
        {
            _orderRepo = orderRepo;
            _foodRepo = foodRepo;
            _ingredientRepo = ingredientRepo;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepo.GetAllOrdersWithItemsAsync();
            var totalOrders = orders.Count();
            var totalRevenue = orders.Sum(o => o.TotalAmount);
            var totalFoods = (await _foodRepo.GetAllAsync()).Count();
            var totalIngredients = (await _ingredientRepo.GetAllAsync()).Count();

            var model = new AdminDashboardViewModel
            {
                TotalOrders = totalOrders,
                TotalRevenue = totalRevenue,
                TotalFoods = totalFoods,
                TotalIngredients = totalIngredients
            };
            return View(model);
        }
    }
}