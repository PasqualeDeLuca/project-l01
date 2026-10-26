using Project_l01.Api.Models;

namespace Project_l01.Api.Data.Seed;

public static class OrderSeed
{
    public static readonly Order[] Data =
    {
        new Order
        {
            Id = 1,
            CustomerId = 1,
            Status = OrderStatus.Completed,
            Total = 1449.96m,
            CreatedAt = new DateTime(2026, 3, 1, 0, 0, 0, DateTimeKind.Utc)
        },
        new Order
        {
            Id = 2,
            CustomerId = 2,
            Status = OrderStatus.Pending,
            Total = 629.98m,
            CreatedAt = new DateTime(2026, 3, 2, 0, 0, 0, DateTimeKind.Utc)
        },
        new Order
        {
            Id = 3,
            CustomerId = 3,
            Status = OrderStatus.Shipped,
            Total = 229.97m,
            CreatedAt = new DateTime(2026, 3, 3, 0, 0, 0, DateTimeKind.Utc)
        },
        new Order
        {
            Id = 4,
            CustomerId = 4,
            Status = OrderStatus.Completed,
            Total = 449.93m,
            CreatedAt = new DateTime(2026, 3, 4, 0, 0, 0, DateTimeKind.Utc)
        }
    };
}