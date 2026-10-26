using Project_l01.Api.Models;

namespace Project_l01.Api.Data.Seed;

public static class OrderItemSeed
{
    public static readonly OrderItem[] Data =
    {
        // Order 1 - Mario Rossi
        new OrderItem
        {
            Id = 1,
            OrderId = 1,
            ProductId = 1,
            Quantity = 1,
            UnitPrice = 1299.99m
        },
        new OrderItem
        {
            Id = 2,
            OrderId = 1,
            ProductId = 2,
            Quantity = 2,
            UnitPrice = 29.99m
        },
        new OrderItem
        {
            Id = 3,
            OrderId = 1,
            ProductId = 3,
            Quantity = 1,
            UnitPrice = 89.99m
        },

        // Order 2 - Laura Bianchi
        new OrderItem
        {
            Id = 4,
            OrderId = 2,
            ProductId = 6,
            Quantity = 1,
            UnitPrice = 349.99m
        },
        new OrderItem
        {
            Id = 5,
            OrderId = 2,
            ProductId = 7,
            Quantity = 1,
            UnitPrice = 279.99m
        },

        // Order 3 - Luca Ferri
        new OrderItem
        {
            Id = 6,
            OrderId = 3,
            ProductId = 8,
            Quantity = 2,
            UnitPrice = 39.99m
        },
        new OrderItem
        {
            Id = 7,
            OrderId = 3,
            ProductId = 9,
            Quantity = 1,
            UnitPrice = 149.99m
        },

        // Order 4 - Giulia Romano
        new OrderItem
        {
            Id = 8,
            OrderId = 4,
            ProductId = 4,
            Quantity = 1,
            UnitPrice = 249.99m
        },
        new OrderItem
        {
            Id = 9,
            OrderId = 4,
            ProductId = 5,
            Quantity = 1,
            UnitPrice = 49.99m
        },
        new OrderItem
        {
            Id = 10,
            OrderId = 4,
            ProductId = 2,
            Quantity = 5,
            UnitPrice = 29.99m
        }
    };
}