using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniAmazonClone.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Users_CreatedByUserUserID",
                        column: x => x.CreatedByUserUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CreatedBy", "CreatedByUserUserID", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, null, "A powerful laptop for professionals.", "Laptop", 1200.00m, 50 },
                    { 2, 1, null, "Latest model smartphone with amazing features.", "Smartphone", 800.00m, 100 },
                    { 3, 1, null, "Noise-canceling headphones for a better sound experience.", "Headphones", 150.00m, 150 },
                    { 4, 1, null, "Wearable smartwatch with fitness tracking features.", "Smartwatch", 250.00m, 200 },
                    { 5, 1, null, "Portable tablet for reading and entertainment.", "Tablet", 350.00m, 120 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", "password123", "Admin" },
                    { 2, "jane.smith@example.com", "Jane Smith", "password123", "Customer" },
                    { 3, "mike.johnson@example.com", "Mike Johnson", "password123", "Customer" },
                    { 4, "emily.davis@example.com", "Emily Davis", "password123", "Customer" },
                    { 5, "chris.lee@example.com", "Chris Lee", "password123", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "OrderDate", "Status", "TotalAmount", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9275), "Pending", 2000.00m, 2 },
                    { 2, new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9291), "Completed", 800.00m, 3 },
                    { 3, new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9293), "Shipped", 150.00m, 4 },
                    { 4, new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9294), "Pending", 1200.00m, 5 },
                    { 5, new DateTime(2025, 3, 22, 22, 16, 45, 161, DateTimeKind.Local).AddTicks(9296), "Completed", 800.00m, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemID", "OrderID", "Price", "ProductID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1200.00m, 1, 1 },
                    { 2, 2, 800.00m, 2, 1 },
                    { 3, 3, 150.00m, 3, 1 },
                    { 4, 4, 250.00m, 4, 1 },
                    { 5, 5, 700.00m, 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductID",
                table: "OrderItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedByUserUserID",
                table: "Products",
                column: "CreatedByUserUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
