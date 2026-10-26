using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_l01.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Electronic devices and accessories", "Electronics" },
                    { 2, "Office equipment and supplies", "Office" },
                    { 3, "Office and business furniture", "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "mario.rossi@example.com", "Mario", "Rossi", "+39 333 1111111" },
                    { 2, new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), "laura.bianchi@example.com", "Laura", "Bianchi", "+39 333 2222222" },
                    { 3, new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), "luca.ferri@example.com", "Luca", "Ferri", "+39 333 3333333" },
                    { 4, new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), "giulia.romano@example.com", "Giulia", "Romano", "+39 333 4444444" },
                    { 5, new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "andrea.conti@example.com", "Andrea", "Conti", "+39 333 5555555" }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Status", "Total" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Completed", 1449.96m },
                    { 2, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Processing", 629.98m },
                    { 3, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Pending", 229.97m },
                    { 4, new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 4, "Completed", 449.93m }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "MinimumStock", "Name", "Price", "Sku", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Professional 15-inch laptop", 5, "Laptop Pro 15", 1299.99m, "ELEC-LAP-001", 15 },
                    { 2, 1, new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Wireless ergonomic mouse", 10, "Wireless Mouse", 29.99m, "ELEC-MOU-001", 50 },
                    { 3, 1, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Mechanical keyboard with backlight", 8, "Mechanical Keyboard", 89.99m, "ELEC-KEY-001", 30 },
                    { 4, 1, new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), "27-inch Full HD monitor", 5, "27-inch Monitor", 249.99m, "ELEC-MON-001", 20 },
                    { 5, 1, new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Multi-port USB-C hub", 10, "USB-C Hub", 49.99m, "ELEC-HUB-001", 40 },
                    { 6, 3, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Large office desk", 3, "Office Desk", 349.99m, "FURN-DES-001", 12 },
                    { 7, 3, new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Ergonomic office chair", 5, "Office Chair", 279.99m, "FURN-CHA-001", 18 },
                    { 8, 2, new DateTime(2026, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), "LED desk lamp", 8, "Desk Lamp", 39.99m, "OFF-LAM-001", 35 },
                    { 9, 2, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Metal filing cabinet", 3, "Filing Cabinet", 149.99m, "OFF-FIL-001", 10 }
                });

            migrationBuilder.InsertData(
                table: "order_items",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1299.99m },
                    { 2, 1, 2, 2, 29.99m },
                    { 3, 1, 3, 1, 89.99m },
                    { 4, 2, 6, 1, 349.99m },
                    { 5, 2, 7, 1, 279.99m },
                    { 6, 3, 8, 2, 39.99m },
                    { 7, 3, 9, 1, 149.99m },
                    { 8, 4, 4, 1, 249.99m },
                    { 9, 4, 5, 1, 49.99m },
                    { 10, 4, 2, 5, 29.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
