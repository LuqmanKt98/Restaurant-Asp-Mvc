namespace WebRestoran.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalFoods { get; set; }
        public int TotalIngredients { get; set; }
    }
}