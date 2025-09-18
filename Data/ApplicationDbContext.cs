using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebRestoran.Models;

namespace WebRestoran.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>  // Promjena iz IdentityDbContext to IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Food { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<FoodIngredient> FoodIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //composite key
            builder.Entity<FoodIngredient>()
                .HasKey(fi => new { fi.FoodId, fi.IngredientId });

            builder.Entity<FoodIngredient>()
                .HasOne(fi => fi.Food)
                .WithMany(f => f.FoodIngredients)
                .HasForeignKey(fi => fi.FoodId);
                //.OnDelete(DeleteBehavior.Cascade);  // Promjena iz Restrict to Cascade - briše sve sastojke jela kada se jelo obriše

            builder.Entity<FoodIngredient>()
                .HasOne(fi => fi.Ingredient)    //bug fix fi.ingredients -> fi.Ingredient
                .WithMany(i => i.FoodIngredients)
                .HasForeignKey(fi => fi.IngredientId);

            //seed data
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Predjelo" },
                new Category { CategoryId = 2, CategoryName = "Glavno jelo" },
                new Category { CategoryId = 3, CategoryName = "Juha" },
                new Category { CategoryId = 4, CategoryName = "Salata" },
                new Category { CategoryId = 5, CategoryName = "Desert" },
                new Category { CategoryId = 6, CategoryName = "Piće" }
            );

            builder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, IngredientName = "Piletina", CurrentStock = 100, MinimumStock = 20, Unit = "kg", CostPerUnit = 15.50m, Supplier = "Local Farm", LastRestocked = new DateTime(2024, 1, 15), CreatedDate = new DateTime(2024, 1, 1), UpdatedDate = new DateTime(2024, 1, 15) },
                new Ingredient { IngredientId = 2, IngredientName = "Junetina", CurrentStock = 80, MinimumStock = 15, Unit = "kg", CostPerUnit = 25.00m, Supplier = "Meat Supplier Co", LastRestocked = new DateTime(2024, 1, 14), CreatedDate = new DateTime(2024, 1, 1), UpdatedDate = new DateTime(2024, 1, 14) },
                new Ingredient { IngredientId = 3, IngredientName = "Svinjetina", CurrentStock = 60, MinimumStock = 10, Unit = "kg", CostPerUnit = 18.75m, Supplier = "Meat Supplier Co", LastRestocked = new DateTime(2024, 1, 13), CreatedDate = new DateTime(2024, 1, 1), UpdatedDate = new DateTime(2024, 1, 13) },
                new Ingredient { IngredientId = 4, IngredientName = "Morski plodovi", CurrentStock = 30, MinimumStock = 8, Unit = "kg", CostPerUnit = 35.00m, Supplier = "Ocean Fresh", LastRestocked = new DateTime(2024, 1, 16), CreatedDate = new DateTime(2024, 1, 1), UpdatedDate = new DateTime(2024, 1, 16) },
                new Ingredient { IngredientId = 5, IngredientName = "Tofu", CurrentStock = 50, MinimumStock = 12, Unit = "kg", CostPerUnit = 8.50m, Supplier = "Vegan Foods Ltd", LastRestocked = new DateTime(2024, 1, 12), CreatedDate = new DateTime(2024, 1, 1), UpdatedDate = new DateTime(2024, 1, 12) },
                new Ingredient { IngredientId = 6, IngredientName = "Povrće", CurrentStock = 200, MinimumStock = 50, Unit = "kg", CostPerUnit = 3.25m, Supplier = "Garden Fresh", LastRestocked = new DateTime(2024, 1, 17), CreatedDate = new DateTime(2024, 1, 1), UpdatedDate = new DateTime(2024, 1, 17) },
                new Ingredient { IngredientId = 7, IngredientName = "Riža", CurrentStock = 150, MinimumStock = 30, Unit = "kg", CostPerUnit = 2.80m, Supplier = "Rice Imports", LastRestocked = new DateTime(2024, 1, 10), CreatedDate = new DateTime(2024, 1, 1), UpdatedDate = new DateTime(2024, 1, 10) },
                new Ingredient { IngredientId = 8, IngredientName = "Tjestenina", CurrentStock = 120, MinimumStock = 25, Unit = "kg", CostPerUnit = 4.20m, Supplier = "Pasta Co", LastRestocked = new DateTime(2024, 1, 11), CreatedDate = new DateTime(2024, 1, 1), UpdatedDate = new DateTime(2024, 1, 11) },
                new Ingredient { IngredientId = 9, IngredientName = "Stakleni rezanci", CurrentStock = 90, MinimumStock = 18, Unit = "kg", CostPerUnit = 6.75m, Supplier = "Asian Foods", LastRestocked = new DateTime(2024, 1, 9), CreatedDate = new DateTime(2024, 1, 1), UpdatedDate = new DateTime(2024, 1, 9) }
            );

            builder.Entity<Food>().HasData(

                // Combinations with main ingredient "Piletina"
                new Food
                {
                    FoodId = 1,
                    FoodName = "Wok Piletina Riža",
                    Description = "Ukusni wok sa Piletinom i Rižom",
                    Price = 10.3m,
                    Stock = 37,
                    CategoryId = 1
                },

        new Food
        {
            FoodId = 2,
            FoodName = "Wok Piletina Tjestenina",
            Description = "Ukusni wok sa Piletinom i Tjesteninom",
            Price = 10.6m,
            Stock = 43,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 3,
            FoodName = "Wok Piletina Stakleni rezanci",
            Description = "Ukusni wok sa Piletinom i Staklenim rezancima",
            Price = 10.9m,
            Stock = 53,
            CategoryId = 1
        },

        // Combinations with main ingredient "Junetina"
        new Food
        {
            FoodId = 4,
            FoodName = "Wok Junetina Riža",
            Description = "Ukusni wok sa Junetinom i Rižom",
            Price = 12.5m,
            Stock = 25,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 5,
            FoodName = "Wok Junetina Tjestenina",
            Description = "Ukusni wok sa Junetinom i Tjesteninom",
            Price = 12.9m,
            Stock = 38,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 6,
            FoodName = "Wok Junetina Stakleni rezanci",
            Description = "Ukusni wok sa Junetinom i Staklenim rezancima",
            Price = 13.1m,
            Stock = 55,
            CategoryId = 1
        },

        // Combinations with main ingredient "Svinjetina"
        new Food
        {
            FoodId = 7,
            FoodName = "Wok Svinjetina Riža",
            Description = "Ukusni wok sa Svinjetinom i Rižom",
            Price = 10.5m,
            Stock = 37,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 8,
            FoodName = "Wok Svinjetina Tjestenina",
            Description = "Ukusni wok sa Svinjetinom i Tjesteninom",
            Price = 10.7m,
            Stock = 45,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 9,
            FoodName = "Wok Svinjetina Stakleni rezanci",
            Description = "Ukusni wok sa Svinjetinom i Staklenim rezancima",
            Price = 11.5m,
            Stock = 28,
            CategoryId = 1
        },

        // Combinations with main ingredient "Morski plodovi"
        new Food
        {
            FoodId = 10,
            FoodName = "Wok Morski plodovi Riža",
            Description = "Ukusni wok sa Morskim plodovima i Rižom",
            Price = 13.5m,
            Stock = 42,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 11,
            FoodName = "Wok Morski plodovi Tjestenina",
            Description = "Ukusni wok sa Morskim plodovima i Tjesteninom",
            Price = 13.7m,
            Stock = 37,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 12,
            FoodName = "Wok Morski plodovi Stakleni rezanci",
            Description = "Ukusni wok sa Morskim plodovima i Staklenim rezancima",
            Price = 13.9m,
            Stock = 34,
            CategoryId = 1
        },

        // Combinations with main ingredient "Tofu"
        new Food
        {
            FoodId = 13,
            FoodName = "Wok Tofu Riža",
            Description = "Ukusni wok sa Tofu i Rižom",
            Price = 10.5m,
            Stock = 28,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 14,
            FoodName = "Wok Tofu Tjestenina",
            Description = "Ukusni wok sa Tofu i Tjesteninom",
            Price = 10.3m,
            Stock = 23,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 15,
            FoodName = "Wok Tofu Stakleni rezanci",
            Description = "Ukusni wok sa Tofu i Staklenim rezancima",
            Price = 10.8m,
            Stock = 36,
            CategoryId = 1
        },

        // Combinations with main ingredient "Povrće"
        new Food
        {
            FoodId = 16,
            FoodName = "Wok Povrće Riža",
            Description = "Ukusni wok sa Povrćem i Rižom",
            Price = 8.5m,
            Stock = 17,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 17,
            FoodName = "Wok Povrće Tjestenina",
            Description = "Ukusni wok sa Povrćem i Tjesteninom",
            Price = 8.5m,
            Stock = 43,
            CategoryId = 1
        },
        new Food
        {
            FoodId = 18,
            FoodName = "Wok Povrće Stakleni rezanci",
            Description = "Ukusni wok sa Povrćem i Staklenim rezancima",
            Price = 8.5m,
            Stock = 36,
            CategoryId = 1

        }
        );
            builder.Entity<FoodIngredient>().HasData(
        // Piletina-based dishes
        new { FoodId = 1, IngredientId = 1 }, new { FoodId = 1, IngredientId = 7 },
        new { FoodId = 2, IngredientId = 1 }, new { FoodId = 2, IngredientId = 8 },
        new { FoodId = 3, IngredientId = 1 }, new { FoodId = 3, IngredientId = 9 },

        // Junetina-based dishes
        new { FoodId = 4, IngredientId = 2 }, new { FoodId = 4, IngredientId = 7 },
        new { FoodId = 5, IngredientId = 2 }, new { FoodId = 5, IngredientId = 8 },
        new { FoodId = 6, IngredientId = 2 }, new { FoodId = 6, IngredientId = 9 },

        // Svinjetina-based dishes
        new { FoodId = 7, IngredientId = 3 }, new { FoodId = 7, IngredientId = 7 },
        new { FoodId = 8, IngredientId = 3 }, new { FoodId = 8, IngredientId = 8 },
        new { FoodId = 9, IngredientId = 3 }, new { FoodId = 9, IngredientId = 9 },

        // Morski plodovi-based dishes
        new { FoodId = 10, IngredientId = 4 }, new { FoodId = 10, IngredientId = 7 },
        new { FoodId = 11, IngredientId = 4 }, new { FoodId = 11, IngredientId = 8 },
        new { FoodId = 12, IngredientId = 4 }, new { FoodId = 12, IngredientId = 9 },

        // Tofu-based dishes
        new { FoodId = 13, IngredientId = 5 }, new { FoodId = 13, IngredientId = 7 },
        new { FoodId = 14, IngredientId = 5 }, new { FoodId = 14, IngredientId = 8 },
        new { FoodId = 15, IngredientId = 5 }, new { FoodId = 15, IngredientId = 9 },

        // Povrće-based dishes
        new { FoodId = 16, IngredientId = 6 }, new { FoodId = 16, IngredientId = 7 },
        new { FoodId = 17, IngredientId = 6 }, new { FoodId = 17, IngredientId = 8 },
        new { FoodId = 18, IngredientId = 6 }, new { FoodId = 18, IngredientId = 9 }
        );

        }
    }

}
