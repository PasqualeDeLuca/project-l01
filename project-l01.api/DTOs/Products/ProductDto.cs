namespace Project_l01.Api.DTOs.Products;

public class ProductDto
{
    public int Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int MinimumStock { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
}