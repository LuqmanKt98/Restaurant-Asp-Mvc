using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebRestoran.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FoodName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ImageThumbnailUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Food_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodIngredients",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodIngredients", x => new { x.FoodId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_FoodIngredients_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Predjelo" },
                    { 2, "Glavno jelo" },
                    { 3, "Juha" },
                    { 4, "Salata" },
                    { 5, "Desert" },
                    { 6, "Piće" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "IngredientName" },
                values: new object[,]
                {
                    { 1, "Piletina" },
                    { 2, "Junetina" },
                    { 3, "Svinjetina" },
                    { 4, "Morski plodovi" },
                    { 5, "Tofu" },
                    { 6, "Povrće" },
                    { 7, "Riža" },
                    { 8, "Tjestenina" },
                    { 9, "Stakleni rezanci" }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "FoodId", "CategoryId", "Description", "FoodName", "ImageThumbnailUrl", "ImageUrl", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Ukusni wok sa Piletinom i Rižom", "Wok Piletina Riža", null, "https://www.placeholder.com/333", 10.3m, 37 },
                    { 2, 1, "Ukusni wok sa Piletinom i Tjesteninom", "Wok Piletina Tjestenina", null, "https://www.placeholder.com/333", 10.6m, 43 },
                    { 3, 1, "Ukusni wok sa Piletinom i Staklenim rezancima", "Wok Piletina Stakleni rezanci", null, "https://www.placeholder.com/333", 10.9m, 53 },
                    { 4, 1, "Ukusni wok sa Junetinom i Rižom", "Wok Junetina Riža", null, "https://www.placeholder.com/333", 12.5m, 25 },
                    { 5, 1, "Ukusni wok sa Junetinom i Tjesteninom", "Wok Junetina Tjestenina", null, "https://www.placeholder.com/333", 12.9m, 38 },
                    { 6, 1, "Ukusni wok sa Junetinom i Staklenim rezancima", "Wok Junetina Stakleni rezanci", null, "https://www.placeholder.com/333", 13.1m, 55 },
                    { 7, 1, "Ukusni wok sa Svinjetinom i Rižom", "Wok Svinjetina Riža", null, "https://www.placeholder.com/333", 10.5m, 37 },
                    { 8, 1, "Ukusni wok sa Svinjetinom i Tjesteninom", "Wok Svinjetina Tjestenina", null, "https://www.placeholder.com/333", 10.7m, 45 },
                    { 9, 1, "Ukusni wok sa Svinjetinom i Staklenim rezancima", "Wok Svinjetina Stakleni rezanci", null, "https://www.placeholder.com/333", 11.5m, 28 },
                    { 10, 1, "Ukusni wok sa Morskim plodovima i Rižom", "Wok Morski plodovi Riža", null, "https://www.placeholder.com/333", 13.5m, 42 },
                    { 11, 1, "Ukusni wok sa Morskim plodovima i Tjesteninom", "Wok Morski plodovi Tjestenina", null, "https://www.placeholder.com/333", 13.7m, 37 },
                    { 12, 1, "Ukusni wok sa Morskim plodovima i Staklenim rezancima", "Wok Morski plodovi Stakleni rezanci", null, "https://www.placeholder.com/333", 13.9m, 34 },
                    { 13, 1, "Ukusni wok sa Tofu i Rižom", "Wok Tofu Riža", null, "https://www.placeholder.com/333", 10.5m, 28 },
                    { 14, 1, "Ukusni wok sa Tofu i Tjesteninom", "Wok Tofu Tjestenina", null, "https://www.placeholder.com/333", 10.3m, 23 },
                    { 15, 1, "Ukusni wok sa Tofu i Staklenim rezancima", "Wok Tofu Stakleni rezanci", null, "https://www.placeholder.com/333", 10.8m, 36 },
                    { 16, 1, "Ukusni wok sa Povrćem i Rižom", "Wok Povrće Riža", null, "https://www.placeholder.com/333", 8.5m, 17 },
                    { 17, 1, "Ukusni wok sa Povrćem i Tjesteninom", "Wok Povrće Tjestenina", null, "https://www.placeholder.com/333", 8.5m, 43 },
                    { 18, 1, "Ukusni wok sa Povrćem i Staklenim rezancima", "Wok Povrće Stakleni rezanci", null, "https://www.placeholder.com/333", 8.5m, 36 }
                });

            migrationBuilder.InsertData(
                table: "FoodIngredients",
                columns: new[] { "FoodId", "IngredientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 7 },
                    { 2, 1 },
                    { 2, 8 },
                    { 3, 1 },
                    { 3, 9 },
                    { 4, 2 },
                    { 4, 7 },
                    { 5, 2 },
                    { 5, 8 },
                    { 6, 2 },
                    { 6, 9 },
                    { 7, 3 },
                    { 7, 7 },
                    { 8, 3 },
                    { 8, 8 },
                    { 9, 3 },
                    { 9, 9 },
                    { 10, 4 },
                    { 10, 7 },
                    { 11, 4 },
                    { 11, 8 },
                    { 12, 4 },
                    { 12, 9 },
                    { 13, 5 },
                    { 13, 7 },
                    { 14, 5 },
                    { 14, 8 },
                    { 15, 5 },
                    { 15, 9 },
                    { 16, 6 },
                    { 16, 7 },
                    { 17, 6 },
                    { 17, 8 },
                    { 18, 6 },
                    { 18, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_CategoryId",
                table: "Food",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodIngredients_IngredientId",
                table: "FoodIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FoodId",
                table: "OrderItems",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FoodIngredients");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
