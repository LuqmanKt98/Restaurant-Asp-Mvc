using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebRestoran.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public required string IngredientName { get; set; }

        [ValidateNever]
        public ICollection<FoodIngredient> FoodIngredients { get; set; }
        
        public Ingredient()
        {
            FoodIngredients = new List<FoodIngredient>();
        }
    }
}