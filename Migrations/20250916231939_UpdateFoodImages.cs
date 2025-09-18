using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebRestoran.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFoodImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Update Food images from placeholder URLs to actual image files
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'chicken_rice.jpg' WHERE FoodId = 1;"); // Wok Piletina Riža
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'chicken_noodles.jpg' WHERE FoodId = 2;"); // Wok Piletina Tjestenina
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'chicken_glass.jpg' WHERE FoodId = 3;"); // Wok Piletina Stakleni rezanci
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'beef.jpg' WHERE FoodId = 4;"); // Wok Junetina Riža
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'beef.jpg' WHERE FoodId = 5;"); // Wok Junetina Tjestenina
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'beef.jpg' WHERE FoodId = 6;"); // Wok Junetina Stakleni rezanci
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'pork_rice.jpg' WHERE FoodId = 7;"); // Wok Svinjetina Riža
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'pork.jpg' WHERE FoodId = 8;"); // Wok Svinjetina Tjestenina
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'pork_glass.jpg' WHERE FoodId = 9;"); // Wok Svinjetina Stakleni rezanci
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'seafood_rice.jpg' WHERE FoodId = 10;"); // Wok Morski plodovi Riža
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'seafood.jpg' WHERE FoodId = 11;"); // Wok Morski plodovi Tjestenina
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'seafood.jpg' WHERE FoodId = 12;"); // Wok Morski plodovi Stakleni rezanci
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'tofu.jpg' WHERE FoodId = 13;"); // Wok Tofu Riža
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'tofu.jpg' WHERE FoodId = 14;"); // Wok Tofu Tjestenina
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'tofu.jpg' WHERE FoodId = 15;"); // Wok Tofu Stakleni rezanci
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'veg_rice.jpg' WHERE FoodId = 16;"); // Wok Povrće Riža
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'veg_noodle.jpg' WHERE FoodId = 17;"); // Wok Povrće Tjestenina
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'veggie.jpg' WHERE FoodId = 18;"); // Wok Povrće Stakleni rezanci
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert back to placeholder URLs
            migrationBuilder.Sql("UPDATE Food SET ImageUrl = 'https://www.placeholder.com/333' WHERE FoodId BETWEEN 1 AND 18;");
        }
    }
}
