using Project_l01.Api.Models;

namespace Project_l01.Api.Data.Seed;

public static class CustomerSeed
{
    public static readonly Customer[] Data =
    {
        new Customer
        {
            Id = 1,
            FirstName = "Mario",
            LastName = "Rossi",
            Email = "mario.rossi@example.com",
            Phone = "+39 333 1111111",
            CreatedAt = new DateTime(2026, 2, 1, 0, 0, 0, DateTimeKind.Utc)
        },
        new Customer
        {
            Id = 2,
            FirstName = "Laura",
            LastName = "Bianchi",
            Email = "laura.bianchi@example.com",
            Phone = "+39 333 2222222",
            CreatedAt = new DateTime(2026, 2, 2, 0, 0, 0, DateTimeKind.Utc)
        },
        new Customer
        {
            Id = 3,
            FirstName = "Luca",
            LastName = "Ferri",
            Email = "luca.ferri@example.com",
            Phone = "+39 333 3333333",
            CreatedAt = new DateTime(2026, 2, 3, 0, 0, 0, DateTimeKind.Utc)
        },
        new Customer
        {
            Id = 4,
            FirstName = "Giulia",
            LastName = "Romano",
            Email = "giulia.romano@example.com",
            Phone = "+39 333 4444444",
            CreatedAt = new DateTime(2026, 2, 4, 0, 0, 0, DateTimeKind.Utc)
        },
        new Customer
        {
            Id = 5,
            FirstName = "Andrea",
            LastName = "Conti",
            Email = "andrea.conti@example.com",
            Phone = "+39 333 5555555",
            CreatedAt = new DateTime(2026, 2, 5, 0, 0, 0, DateTimeKind.Utc)
        }
    };
}