using System;
using System.Collections.Generic;

namespace WebRestoran.TempModels;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int FoodId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual Food Food { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
