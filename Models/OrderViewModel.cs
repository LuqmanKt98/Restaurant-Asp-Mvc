namespace WebRestoran.Models
{
    public class OrderViewModel
    {
        public IEnumerable<Food> Products { get; set; } = new List<Food>();
        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
        public decimal TotalAmount { get; set; }
    }
}
