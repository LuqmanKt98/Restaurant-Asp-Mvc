using System;
using System.Collections.Generic;

namespace WebRestoran.TempModels;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
}
