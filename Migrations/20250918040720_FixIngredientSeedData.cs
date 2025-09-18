using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebRestoran.Migrations
{
    /// <inheritdoc />
    public partial class FixIngredientSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 15.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20m, "Local Farm", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 25.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80m, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 15m, "Meat Supplier Co", new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 18.75m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, "Meat Supplier Co", new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 35.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 8m, "Ocean Fresh", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 8.50m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, "Vegan Foods Ltd", new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 3.25m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, "Garden Fresh", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 2.80m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150m, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, "Rice Imports", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 4.20m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120m, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, "Pasta Co", new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 6.75m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 18m, "Asian Foods", new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 423, DateTimeKind.Local).AddTicks(7980), 0m, null, 0m, null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(764), 0m, null, 0m, null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(781), 0m, null, 0m, null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(782), 0m, null, 0m, null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(783), 0m, null, 0m, null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(785), 0m, null, 0m, null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(786), 0m, null, 0m, null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(787), 0m, null, 0m, null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(830), 0m, null, 0m, null, null });
        }
    }
}
