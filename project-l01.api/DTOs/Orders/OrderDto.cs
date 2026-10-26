using Project_l01.Api.DTOs.Customers;
using Project_l01.Api.Models;

public class OrderDto
{
    public int Id { get; set; }
    public CustomerDto Customer { get; set; } = null!;
    public OrderStatus Status { get; set;}
    public List<OrderItemDto> Items { get; set; } = new();
    public decimal Total { get; set; }

}