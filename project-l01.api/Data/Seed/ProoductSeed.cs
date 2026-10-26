using Project_l01.Api.Models;

namespace Project_l01.Api.Data.Seed;

public static class ProductSeed
{
    public static readonly Product[] Data =
    {
        new Product
        {
            Id = 1,
            Sku = "ELEC-LAP-001",
            Name = "Laptop Pro 15",
            Description = "Professional 15-inch laptop",
            Price = 1299.99m,
            StockQuantity = 15,
            MinimumStock = 5,
            CategoryId = 1,
            CreatedAt = new DateTime(2026, 1, 10, 0, 0, 0, DateTimeKind.Utc)
        },
        new Product
        {
            Id = 2,
            Sku = "ELEC-MOU-001",
            Name = "Wireless Mouse",
            Description = "Wireless ergonomic mouse",
            Price = 29.99m,
            StockQuantity = 50,
            MinimumStock = 10,
            CategoryId = 1,
            CreatedAt = new DateTime(2026, 1, 11, 0, 0, 0, DateTimeKind.Utc)
        },
        new Product
        {
            Id = 3,
            Sku = "ELEC-KEY-001",
            Name = "Mechanical Keyboard",
            Description = "Mechanical keyboard with backlight",
            Price = 89.99m,
            StockQuantity = 30,
            MinimumStock = 8,
            CategoryId = 1,
            CreatedAt = new DateTime(2026, 1, 12, 0, 0, 0, DateTimeKind.Utc)
        },
        new Product
        {
            Id = 4,
            Sku = "ELEC-MON-001",
            Name = "27-inch Monitor",
            Description = "27-inch Full HD monitor",
            Price = 249.99m,
            StockQuantity = 20,
            MinimumStock = 5,
            CategoryId = 1,
            CreatedAt = new DateTime(2026, 1, 13, 0, 0, 0, DateTimeKind.Utc)
        },
        new Product
        {
            Id = 5,
            Sku = "ELEC-HUB-001",
            Name = "USB-C Hub",
            Description = "Multi-port USB-C hub",
            Price = 49.99m,
            StockQuantity = 40,
            MinimumStock = 10,
            CategoryId = 1,
            CreatedAt = new DateTime(2026, 1, 14, 0, 0, 0, DateTimeKind.Utc)
        },
        new Product
        {
            Id = 6,
            Sku = "FURN-DES-001",
            Name = "Office Desk",
            Description = "Large office desk",
            Price = 349.99m,
            StockQuantity = 12,
            MinimumStock = 3,
            CategoryId = 3,
            CreatedAt = new DateTime(2026, 1, 15, 0, 0, 0, DateTimeKind.Utc)
        },
        new Product
        {
            Id = 7,
            Sku = "FURN-CHA-001",
            Name = "Office Chair",
            Description = "Ergonomic office chair",
            Price = 279.99m,
            StockQuantity = 18,
            MinimumStock = 5,
            CategoryId = 3,
            CreatedAt = new DateTime(2026, 1, 16, 0, 0, 0, DateTimeKind.Utc)
        },
        new Product
        {
            Id = 8,
            Sku = "OFF-LAM-001",
            Name = "Desk Lamp",
            Description = "LED desk lamp",
            Price = 39.99m,
            StockQuantity = 35,
            MinimumStock = 8,
            CategoryId = 2,
            CreatedAt = new DateTime(2026, 1, 17, 0, 0, 0, DateTimeKind.Utc)
        },
        new Product
        {
            Id = 9,
            Sku = "OFF-FIL-001",
            Name = "Filing Cabinet",
            Description = "Metal filing cabinet",
            Price = 149.99m,
            StockQuantity = 10,
            MinimumStock = 3,
            CategoryId = 2,
            CreatedAt = new DateTime(2026, 1, 18, 0, 0, 0, DateTimeKind.Utc)
        }
    };
}