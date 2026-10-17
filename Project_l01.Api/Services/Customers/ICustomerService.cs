using Project_l01.Api.DTOs.Customers;
using Project_l01.Api.Services.Customers;

namespace Project_l01.Api.Services;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllAsync();
    Task<CustomerDto?> GetByIdAsync(int id);
    Task<CustomerDto> CreateAsync(CreateCustomerDto dto);
    Task<CustomerDto?> UpdateAsync(int id, UpdateCustomerDto dto);
    Task<DeleteCustomerResult> DeleteAsync(int id); 
}