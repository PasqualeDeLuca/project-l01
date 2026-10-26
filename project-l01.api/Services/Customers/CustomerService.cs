

using Project_l01.Api.DTOs.Customers;
using Project_l01.Api.Services.Customers;
using Project_l01.Api.Models;
using Project_l01.Api.Repositories;

namespace Project_l01.Api.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();

        return customers
            .Select(MapToDto)
            .ToList();
    }

    public async Task<CustomerDto?> GetByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer is null)
        {
            return null;
        }

        return MapToDto(customer);
    }

    public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
    {
        var customer = new Customer
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone
        };

        var createdCustomer = await _customerRepository.CreateAsync(customer);

        return MapToDto(createdCustomer);
    }

    public async Task<CustomerDto?> UpdateAsync(int id, UpdateCustomerDto dto)
    {
        var customer = new Customer
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone
        };

        var updateCustomer = await _customerRepository.UpdateAsync(customer);

        if (updateCustomer is null)
        {
            return null;
        } 

        return MapToDto(updateCustomer);
    }

    public async Task<DeleteCustomerResult> DeleteAsync(int id)
    {

        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer is null)
        {
            return DeleteCustomerResult.NotFound;
        }

        var hasOrders = await _customerRepository.HasOrdersAsync(id);

        if (hasOrders)
        {
            return DeleteCustomerResult.HasOrders;
        }
        
        await _customerRepository.DeleteAsync(id);

        return DeleteCustomerResult.Deleted;
    }

    private static CustomerDto MapToDto(Customer customer)
    {
        
        return new CustomerDto
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone
        };
    }
}