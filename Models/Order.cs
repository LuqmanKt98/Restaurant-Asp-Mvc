namespace WebRestoran.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed,
        Cancelled
    }

    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
            Status = OrderStatus.Pending;
            OrderDate = DateTime.Now;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string? Comment { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? EstimatedDeliveryTime { get; set; }
        public string? StatusNotes { get; set; }
        public string? ProcessedBy { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        
        // Computed properties for better UI display
        public string StatusDisplayName => Status switch
        {
            OrderStatus.Pending => "Pending",
            OrderStatus.Processing => "Processing",
            OrderStatus.Completed => "Completed",
            OrderStatus.Cancelled => "Cancelled",
            _ => "Unknown"
        };
        
        public string StatusBadgeClass => Status switch
        {
            OrderStatus.Pending => "warning",
            OrderStatus.Processing => "info",
            OrderStatus.Completed => "success",
            OrderStatus.Cancelled => "danger",
            _ => "secondary"
        };
        
        public bool CanBeCancelled => Status == OrderStatus.Pending;
        public bool CanBeProcessed => Status == OrderStatus.Pending;
        public bool CanBeCompleted => Status == OrderStatus.Processing;
    }
}
