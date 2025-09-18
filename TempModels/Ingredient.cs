using System;
using System.Collections.Generic;

namespace WebRestoran.TempModels;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string IngredientName { get; set; } = null!;

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
}
