namespace WebRestoran.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        // Basic Statistics
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalFoods { get; set; }
        public int TotalIngredients { get; set; }
        public int TotalUsers { get; set; }
        
        // Revenue Analytics
        public decimal TodayRevenue { get; set; }
        public decimal WeekRevenue { get; set; }
        public decimal MonthRevenue { get; set; }
        public decimal YearRevenue { get; set; }
        
        // Order Analytics
        public int TodayOrders { get; set; }
        public int WeekOrders { get; set; }
        public int MonthOrders { get; set; }
        public int PendingOrders { get; set; }
        public int ProcessingOrders { get; set; }
        public int CompletedOrders { get; set; }
        public int CancelledOrders { get; set; }
        
        // Performance Metrics
        public decimal AverageOrderValue { get; set; }
        public decimal RevenuePerUser { get; set; }
        public decimal OrdersPerUser { get; set; }
        public decimal RevenueGrowthPercentage { get; set; }
        public decimal OrderGrowthPercentage { get; set; }
        
        // Inventory Insights
        public int LowStockItems { get; set; }
        public int OutOfStockItems { get; set; }
        public decimal TotalInventoryValue { get; set; }
        
        // Top Performing Items
        public List<TopPerformingItem> TopSellingFoods { get; set; } = new List<TopPerformingItem>();
        public List<RecentOrderSummary> RecentOrders { get; set; } = new List<RecentOrderSummary>();
    }
    
    public class TopPerformingItem
    {
        public string Name { get; set; }
        public int OrderCount { get; set; }
        public decimal Revenue { get; set; }
    }
    
    public class RecentOrderSummary
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}