

using Project_l01.Api.Models;

namespace Project_l01.Api.Repositories;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer?> UpdateAsync(Customer customer);
    Task<bool> DeleteAsync(int id);
    Task<bool> HasOrdersAsync(int customerId);
}