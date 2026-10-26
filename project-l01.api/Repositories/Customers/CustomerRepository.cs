

using Microsoft.EntityFrameworkCore;
using Project_l01.Api.Data;
using Project_l01.Api.Models;


namespace Project_l01.Api.Repositories;

public class CustomerRepository: ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(customer => customer.Id == id);
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task<Customer?> UpdateAsync(Customer customer)
    {

        var existingCustomer = await _context.Customers.FirstOrDefaultAsync(existing => existing.Id == customer.Id);

        if (existingCustomer is null)
        {
            return null;
        }

        existingCustomer.FirstName = customer.FirstName;
        existingCustomer.LastName = customer.LastName;
        existingCustomer.Email = customer.Email;
        existingCustomer.Phone = customer.Phone;

        await _context.SaveChangesAsync();

        return existingCustomer;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);

        if (customer is null)
        {
            return false;
        }

        _context.Customers.Remove(customer);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> HasOrdersAsync(int customerId)
    {
        return await _context.Orders.AnyAsync(order => order.CustomerId == customerId);
    }
}