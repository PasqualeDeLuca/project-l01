using System.ComponentModel.DataAnnotations;

namespace Project_l01.Api.DTOs.Products;


public class UpdateProductDto
{
    [Required]
    [StringLength(50)]
    public string Sku { get; set; } = string.Empty;

    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }

    [Range(0, int.MaxValue)]
    public int MinimumStock { get; set; }

    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }

}