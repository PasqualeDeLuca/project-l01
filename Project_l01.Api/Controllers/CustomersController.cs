

using Microsoft.AspNetCore.Mvc;
using Project_l01.Api.DTOs.Customers;
using Project_l01.Api.Services.Customers;
using Project_l01.Api.Services;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomer()
    {
        var customers = await _customerService.GetAllAsync();

        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerDto>> GetById(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerDto dto)
    {
        try
        {
            var customer = await _customerService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = customer.Id },
                customer
            );
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new
            {
                message = ex.Message
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerDto>> UpdateCustomer(int id, UpdateCustomerDto dto)
    {
        var customer = await _customerService.UpdateAsync(id, dto);

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var result = await _customerService.DeleteAsync(id);

        return result switch
        {
            DeleteCustomerResult.NotFound => 
                NotFound(),

            DeleteCustomerResult.HasOrders => 
                Conflict(new
                {
                    message = "Cannot delete a customer with existing orders."
                }),

            DeleteCustomerResult.Deleted => 
                NoContent(),

            _ => StatusCode(500)
        };
    }
}