using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRestoran.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using WebRestoran.Models.ViewModels;

namespace WebRestoran.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IRepo<Order> _orderRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IRepo<Order> orderRepo, UserManager<ApplicationUser> userManager)
        {
            _orderRepo = orderRepo;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var all = await _orderRepo.GetAllOrdersWithItemsAsync();
            var currentUserId = _userManager.GetUserId(User);
            var myOrders = all.Where(o => o.UserId == currentUserId).ToList();

            var model = new UserDashboardViewModel
            {
                RecentOrders = myOrders.OrderByDescending(o => o.OrderDate).Take(5).ToList(),
                TotalSpent = myOrders.Sum(o => o.TotalAmount)
            };
            return View(model);
        }
    }
}