

using Project_l01.Api.Models;
using Project_l01.Api.Repositories;
using Project_l01.Api.DTOs.Customers;

namespace Project_l01.Api.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }


    public async Task<List<OrderDto>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync();

        return orders.Select(MapToDto).ToList();
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order is null)
        {
            return null;
        }

        return MapToDto(order);
    }

    public async Task<OrderDto> CreateAsync(CreateOrderDto request)
    {
        var customer = await _customerRepository
            .GetByIdAsync(request.CustomerId);

        if (customer is null)
        {
            throw new KeyNotFoundException($"Customer with id {request.CustomerId} was not found.");

        }

        if (request.Items is null || request.Items.Count == 0)
        {
            throw new ArgumentException("An order must contain at least one item.");
        }

        if (request.Items.Any(item => item.Quantity <= 0))
        {
            throw new ArgumentException("Order item quantity must be greater than zero.");
        }
    
        var orderItems = new List<OrderItem>();

        foreach (var itemDto in request.Items)
        {
            var product = await _productRepository.GetByIdAsync(itemDto.ProductId);

            if (product is null)
            {
                throw new KeyNotFoundException($"Product with id {itemDto.ProductId} was not found.");
            }

            var orderItem = new OrderItem
            {
                ProductId = product.Id,
                Quantity = itemDto.Quantity,
                UnitPrice = product.Price
            };

            orderItems.Add(orderItem);
        }

        var total = orderItems.Sum(item => item.UnitPrice * item.Quantity);

        var order = new Order
        {
            CustomerId = request.CustomerId,
            Status = OrderStatus.Pending,
            Total = total,
            CreatedAt = DateTime.UtcNow,
            Items = orderItems
        };
        
        var createdOrder = await _orderRepository.AddAsync(order);
    
        return MapToDto(createdOrder);
    }


    private static OrderDto MapToDto(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            Customer = new CustomerDto
            {
                Id = order.Customer.Id,
                FirstName = order.Customer.FirstName,
                LastName = order.Customer.LastName,
                Email = order.Customer.Email
            },
            Status = order.Status,
            Total = order.Total,

            Items = order.Items.Select(item => new OrderItemDto
            {
                ProductId = item.ProductId,
                ProductName = item.Product.Name,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Subtotal = item.UnitPrice * item.Quantity
            }).ToList()
        };
    }



}