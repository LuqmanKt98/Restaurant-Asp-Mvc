using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebRestoran.Migrations
{
    /// <inheritdoc />
    public partial class RestoreUnsplashImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Chicken dishes (Piletina)
            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1603133872878-684f208fb84b?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Chicken Rice

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1569718212165-3a8278d5f624?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Chicken Noodles

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1617093727343-374698b1b08d?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Chicken Glass Noodles

            // Beef dishes (Junetina)
            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1546833999-b9f581a1996d?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Beef Rice

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1551782450-17144efb9c50?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Beef Noodles

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1588347818133-38c4106ca7b4?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Beef Glass Noodles

            // Pork dishes (Svinjetina)
            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1565299624946-b28f40a0ca4b?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Pork Rice

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1612929633738-8fe44f7ec841?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Pork Noodles

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1585032226651-759b368d7246?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Pork Glass Noodles

            // Seafood dishes (Morski plodovi)
            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1559847844-5315695dadae?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Seafood Rice

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1563379091339-03246963d51a?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Seafood Noodles

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1565299507177-b0ac66763828?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Seafood Glass Noodles

            // Tofu dishes (Tofu)
            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1546069901-ba9599a7e63c?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Tofu Rice

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1565299624946-b28f40a0ca4b?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Tofu Noodles

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1582878826629-29b7ad1cdc43?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Tofu Glass Noodles

            // Vegetable dishes (Povrće)
            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 16,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Vegetable Rice

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1551782450-17144efb9c50?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Vegetable Noodles

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1565299507177-b0ac66763828?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80"); // Vegetable Glass Noodles
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 4,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 5,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 6,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 7,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 8,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 9,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 10,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 11,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 12,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 13,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 14,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 15,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 16,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 17,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "FoodId",
                keyValue: 18,
                column: "ImageUrl",
                value: null);
        }
    }
}
