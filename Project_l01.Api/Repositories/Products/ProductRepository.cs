using Microsoft.EntityFrameworkCore;
using Project_l01.Api.Data;
using Project_l01.Api.Models;


namespace Project_l01.Api.Products;

public class ProductRepository : IProductRepository
{
    
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .FirstOrDefaultAsync(product => product.Id == id);
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return product;
    }


    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CategoryExistAsync(int categoryId)
    {
        return await _context.Categories
            .AnyAsync(category => category.Id == categoryId);
    }

    public IQueryable<Product> GetQueryable()
    {
        return _context.Products
            .Include(product => product.Category);
    }
}