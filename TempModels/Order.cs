using System;
using System.Collections.Generic;

namespace WebRestoran.TempModels;

public partial class Order
{
    public int OrderId { get; set; }

    public string UserId { get; set; } = null!;

    public string? Comment { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual AspNetUser User { get; set; } = null!;
}
