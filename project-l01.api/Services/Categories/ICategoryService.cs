
using Project_l01.Api.DTOs.Categories;

namespace Project_l01.Api.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<CategoryDto?> GetByIdAsync(int id);
    Task<CategoryDto> CreateAsync(CreateCategoryDto category);
    Task<bool> UpdateAsync(int id, UpdateCategoryDto category);
    Task<DeleteCategoryResult> DeleteAsync(int id);
}