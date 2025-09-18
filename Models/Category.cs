namespace WebRestoran.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public ICollection<Food> Products { get; set; }
        
        public Category()
        {
            Products = new List<Food>();
        }
    }
}