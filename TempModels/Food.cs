using System;
using System.Collections.Generic;

namespace WebRestoran.TempModels;

public partial class Food
{
    public int FoodId { get; set; }

    public string FoodName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public int Stock { get; set; }

    public string? ImageUrl { get; set; }

    public string? ImageThumbnailUrl { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
