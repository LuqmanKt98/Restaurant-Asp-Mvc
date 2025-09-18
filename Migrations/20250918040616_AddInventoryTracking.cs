using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebRestoran.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CostPerUnit",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentStock",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRestocked",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumStock",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "Unit", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 423, DateTimeKind.Local).AddTicks(7980), 0m, null, 0m, null, "kg", null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "Unit", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(764), 0m, null, 0m, null, "kg", null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "Unit", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(781), 0m, null, 0m, null, "kg", null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "Unit", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(782), 0m, null, 0m, null, "kg", null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "Unit", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(783), 0m, null, 0m, null, "kg", null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "Unit", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(785), 0m, null, 0m, null, "kg", null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "Unit", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(786), 0m, null, 0m, null, "kg", null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "Unit", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(787), 0m, null, 0m, null, "kg", null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "CostPerUnit", "CreatedDate", "CurrentStock", "LastRestocked", "MinimumStock", "Supplier", "Unit", "UpdatedDate" },
                values: new object[] { 0m, new DateTime(2025, 9, 18, 9, 6, 14, 425, DateTimeKind.Local).AddTicks(830), 0m, null, 0m, null, "kg", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CostPerUnit",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CurrentStock",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "LastRestocked",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MinimumStock",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Ingredients");
        }
    }
}
