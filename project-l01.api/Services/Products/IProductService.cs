

using Project_l01.Api.Controllers;
using Project_l01.Api.DTOs.Common;
using Project_l01.Api.DTOs.Products;
using Project_l01.Api.Models;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(int id);
    Task<ProductDto> CreateAsync(CreateProductDto product);
    Task<ProductDto?> UpdateAsync(int id, UpdateProductDto product);
    Task<bool> DeleteAsync(int id);

    Task<PagedResult<ProductDto>> GetPagedAsync(ProductQueryParameters parameters);
}