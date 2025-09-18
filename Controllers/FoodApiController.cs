using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRestoran.Data;
using WebRestoran.Models;

namespace WebRestoran.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class FoodApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepo<Food> _foodRepo;
        private readonly IRepo<Ingredient> _ingredientRepo;
        private readonly IRepo<FoodIngredient> _foodIngredientRepo;

        public FoodApiController(
            ApplicationDbContext context,
            IRepo<Food> foodRepo,
            IRepo<Ingredient> ingredientRepo,
            IRepo<FoodIngredient> foodIngredientRepo)
        {
            _context = context;
            _foodRepo = foodRepo;
            _ingredientRepo = ingredientRepo;
            _foodIngredientRepo = foodIngredientRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodDetails(int id)
        {
            try
            {
                // Get food with category
                var food = await _context.Food
                    .Include(f => f.Category)
                    .FirstOrDefaultAsync(f => f.FoodId == id);

                if (food == null)
                {
                    return NotFound(new { message = "Food item not found" });
                }

                // Get ingredients for this food
                var ingredients = await _context.FoodIngredients
                    .Where(fi => fi.FoodId == id)
                    .Include(fi => fi.Ingredient)
                    .Select(fi => new
                    {
                        id = fi.Ingredient!.IngredientId,
                        name = fi.Ingredient.IngredientName
                    })
                    .ToListAsync();

                // Create response object with comprehensive food information
                var response = new
                {
                    id = food.FoodId,
                    name = food.FoodName,
                    description = food.Description,
                    price = food.Price,
                    stock = food.Stock,
                    imageUrl = food.ImageUrl,
                    category = food.Category?.CategoryName ?? "Uncategorized",
                    ingredients = ingredients,
                    // Sample nutritional data - you can extend this based on your needs
                    nutrition = new
                    {
                        calories = GetEstimatedCalories(food.FoodName),
                        protein = GetEstimatedProtein(food.FoodName),
                        carbs = GetEstimatedCarbs(food.FoodName),
                        fat = GetEstimatedFat(food.FoodName),
                        fiber = GetEstimatedFiber(food.FoodName),
                        sodium = GetEstimatedSodium(food.FoodName)
                    },
                    // Sample preparation steps - you can extend this based on your needs
                    preparationSteps = GetPreparationSteps(food.FoodName)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching food details", error = ex.Message });
            }
        }

        // Helper methods for estimated nutritional values
        // These are sample implementations - you should replace with actual data
        private int GetEstimatedCalories(string foodName)
        {
            var random = new Random(foodName.GetHashCode());
            return random.Next(200, 800); // Random calories between 200-800
        }

        private int GetEstimatedProtein(string foodName)
        {
            var random = new Random(foodName.GetHashCode());
            return random.Next(10, 50); // Random protein between 10-50g
        }

        private int GetEstimatedCarbs(string foodName)
        {
            var random = new Random(foodName.GetHashCode());
            return random.Next(20, 80); // Random carbs between 20-80g
        }

        private int GetEstimatedFat(string foodName)
        {
            var random = new Random(foodName.GetHashCode());
            return random.Next(5, 30); // Random fat between 5-30g
        }

        private int GetEstimatedFiber(string foodName)
        {
            var random = new Random(foodName.GetHashCode());
            return random.Next(2, 15); // Random fiber between 2-15g
        }

        private int GetEstimatedSodium(string foodName)
        {
            var random = new Random(foodName.GetHashCode());
            return random.Next(100, 1000); // Random sodium between 100-1000mg
        }

        // Helper method for preparation steps
        private List<string> GetPreparationSteps(string foodName)
        {
            // Sample preparation steps - you can customize based on food type
            var steps = new List<string>();
            
            if (foodName.ToLower().Contains("pizza"))
            {
                steps.AddRange(new[]
                {
                    "Preheat oven to 450°F (230°C)",
                    "Prepare pizza dough and roll it out",
                    "Spread sauce evenly over the dough",
                    "Add cheese and desired toppings",
                    "Bake for 12-15 minutes until crust is golden",
                    "Let cool for 2-3 minutes before serving"
                });
            }
            else if (foodName.ToLower().Contains("pasta"))
            {
                steps.AddRange(new[]
                {
                    "Bring a large pot of salted water to boil",
                    "Add pasta and cook according to package directions",
                    "Meanwhile, prepare the sauce in a separate pan",
                    "Drain pasta, reserving 1 cup of pasta water",
                    "Combine pasta with sauce, adding pasta water if needed",
                    "Serve immediately with fresh herbs and cheese"
                });
            }
            else if (foodName.ToLower().Contains("salad"))
            {
                steps.AddRange(new[]
                {
                    "Wash and dry all fresh ingredients thoroughly",
                    "Chop vegetables into bite-sized pieces",
                    "Prepare dressing by whisking ingredients together",
                    "Combine all salad ingredients in a large bowl",
                    "Drizzle with dressing and toss gently",
                    "Serve immediately for best freshness"
                });
            }
            else
            {
                steps.AddRange(new[]
                {
                    "Gather all required ingredients and equipment",
                    "Prepare ingredients according to recipe specifications",
                    "Follow cooking method as per traditional preparation",
                    "Monitor cooking time and temperature carefully",
                    "Check for doneness before serving",
                    "Garnish and serve while hot"
                });
            }
            
            return steps;
        }
    }
}