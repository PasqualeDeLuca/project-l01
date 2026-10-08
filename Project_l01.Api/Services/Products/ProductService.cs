using Microsoft.EntityFrameworkCore;
using Project_l01.Api.DTOs.Common;
using Project_l01.Api.DTOs.Products;
using Project_l01.Api.Models;

namespace Project_l01.Api.Services;

public class ProductService : IProductService
{
    
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(MapToDto);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        return product is null
            ? null
            : MapToDto(product);
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var categoryExist = await _productRepository.CategoryExistAsync(dto.CategoryId);

        if (!categoryExist)
        {
            throw new ArgumentException("Category does not exist.");
        }

        var product = new Product
        {
            Sku = dto.Sku,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            StockQuantity = dto.StockQuantity,
            MinimumStock = dto.MinimumStock,
            CategoryId = dto.CategoryId,
            CreatedAt = DateTime.UtcNow
        };

        var createdProduct = await _productRepository.AddAsync(product);

        return MapToDto(createdProduct);
    }

    public async Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);

        if (existingProduct is null)
        {
            return null;
        }

        var categoryExist = await _productRepository.CategoryExistAsync(dto.CategoryId);

        if (!categoryExist)
        {
            throw new ArgumentException("Category does not exist.");
        }

        existingProduct.Sku = dto.Sku;
        existingProduct.Name = dto.Name;
        existingProduct.Description = dto.Description;
        existingProduct.Price = dto.Price;
        existingProduct.StockQuantity = dto.StockQuantity;
        existingProduct.MinimumStock = dto.MinimumStock;
        existingProduct.CategoryId = dto.CategoryId;

        await _productRepository.UpdateAsync(existingProduct);

        return MapToDto(existingProduct);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if(product is null)
        {
            return false;
        }

        await _productRepository.DeleteAsync(product);

        return true;
    }


    public async Task<PagedResult<ProductDto>> GetPagedAsync(ProductQueryParameters parameters)
    {
        var query = _productRepository.GetQueryable();

        if (!string.IsNullOrWhiteSpace(parameters.Search))
        {
            query = query.Where(product => product.Name.Contains(parameters.Search));
        }

        if (parameters.CategoryId.HasValue)
        {
            query = query.Where(product => product.CategoryId == parameters.CategoryId.Value);
        }

        if (parameters.MinPrice.HasValue)
        {
            query = query.Where(product => product.Price >= parameters.MinPrice.Value);
        }

        if (parameters.MaxPrice.HasValue)
        {
            query = query.Where(product => product.Price <= parameters.MaxPrice.Value);
        }

        if (parameters.LowStock == true)
        {
            query = query.Where(product => product.StockQuantity < 10);
        }

        if(!string.IsNullOrWhiteSpace(parameters.SortBy))
        {
            var sortDirection = parameters.SortDirection?.ToLower();

            query = parameters.SortBy.ToLower() switch
            {
                "name" => sortDirection == "desc"
                    ? query.OrderByDescending(product => product.Name)
                    : query.OrderBy(product => product.Name),

                "price" => sortDirection == "desc"
                    ? query.OrderByDescending(product => product.Price)
                    : query.OrderBy(product => product.Price),

                "stock" => sortDirection == "desc"
                    ? query.OrderByDescending(product => product.StockQuantity)
                    : query.OrderBy(product => product.StockQuantity),

                _ => query
            };
        }

        var totalCount = await query.CountAsync();

        var products = await query
            .Skip((parameters.Page - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();

        return new PagedResult<ProductDto>
        {
            Items = products.Select(MapToDto).ToList(),
            TotalCount = totalCount,
            Page = parameters.Page,
            PageSize = parameters.PageSize,
            TotalPages = (int)Math.Ceiling(totalCount / (double)parameters.PageSize)
        };
    }

    private static ProductDto MapToDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Sku = product.Sku,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            MinimumStock = product.MinimumStock,
            CategoryId = product.CategoryId,
            CreatedAt = product.CreatedAt
        };
    }
}