using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebRestoran.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        
        [Required]
        public required string IngredientName { get; set; }
        
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be a positive number")]
        public decimal CurrentStock { get; set; }
        
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Minimum stock must be a positive number")]
        public decimal MinimumStock { get; set; }
        
        [Required]
        public string Unit { get; set; } = "kg"; // kg, liters, pieces, etc.
        
        [Range(0, double.MaxValue, ErrorMessage = "Cost per unit must be a positive number")]
        public decimal CostPerUnit { get; set; }
        
        public string? Supplier { get; set; }
        
        public DateTime? LastRestocked { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }

        [ValidateNever]
        public ICollection<FoodIngredient> FoodIngredients { get; set; }
        
        // Computed properties
        public bool IsLowStock => CurrentStock <= MinimumStock;
        
        public decimal TotalValue => CurrentStock * CostPerUnit;
        
        public Ingredient()
        {
            FoodIngredients = new List<FoodIngredient>();
        }
    }
}