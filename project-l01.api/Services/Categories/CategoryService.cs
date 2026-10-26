using Microsoft.VisualBasic;
using Project_l01.Api.DTOs.Categories;
using Project_l01.Api.Models;
using Project_l01.Api.Repositories;

namespace Project_l01.Api.Services;

public class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories.Select(MapToDto);
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        return category is null
            ? null
            : MapToDto(category);
    }

    public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description
        };

        var createdCategory = await _categoryRepository.AddAsync(category);

        return MapToDto(createdCategory);
    }

    public async Task<bool> UpdateAsync(int id, UpdateCategoryDto dto)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(id);

        if (existingCategory is null)
        {
            return false;
        }

        existingCategory.Name = dto.Name;
        existingCategory.Description = dto.Description;

        await _categoryRepository.UpdateAsync(existingCategory);

        return true;
    }

    public async Task<DeleteCategoryResult> DeleteAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null)
        {
            return DeleteCategoryResult.NotFound;
        }

        var hasProducts = await _categoryRepository.HasProductsAsync(id);

        if (hasProducts)
        {
            return DeleteCategoryResult.HasProducts;
        }

        await _categoryRepository.DeleteAsync(category);

        return DeleteCategoryResult.Deleted;
    }

    private static CategoryDto MapToDto(Category category)
    {
        return new CategoryDto
        {
        Id = category.Id,
        Name = category.Name,
        Description = category.Description
        };
    }

    
}