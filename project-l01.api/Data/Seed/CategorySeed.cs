using Project_l01.Api.Models;

namespace Project_l01.Api.Data.Seed;

public static class CategorySeed
{
    
    public static readonly Category[] Data =
    {
        new Category
        {
            Id = 1,
            Name = "Electronics",
            Description = "Electronic devices and accessories"
        },
        new Category
        {
            Id = 2,
            Name = "Office",
            Description = "Office equipment and supplies"
        },
        new Category
        {
            Id = 3,
            Name = "Furniture",
            Description = "Office and business furniture"
        }
    };
}