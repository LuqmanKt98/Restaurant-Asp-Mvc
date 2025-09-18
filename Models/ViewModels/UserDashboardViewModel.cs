using System.Collections.Generic;

namespace WebRestoran.Models.ViewModels
{
    public class UserDashboardViewModel
    {
        public List<Order> RecentOrders { get; set; } = new();
        public decimal TotalSpent { get; set; }
    }
}