using Microsoft.EntityFrameworkCore;
using Project_l01.Api.Data;
using Project_l01.Api.Models;

namespace Project_l01.Api.Repositories;


public class CategoryRepository : ICategoryRepository
{
    
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories
            .ToListAsync(); 
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(category => category.Id == id);
    }

    public async Task<Category> AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);

        await _context.SaveChangesAsync();

        return category;
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category category)
    {
        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> HasProductsAsync(int categoryId)
    {
        return await _context.Products
            .AnyAsync(product => product.CategoryId == categoryId);
    }
}