using Store.Services.OrderItems.Contracts.Dtos;

namespace Store.Applications.CreateOrder.Contracts.Dtos;

public class AddOrderDto
{
    public int CustomerId { get; set; }
    public List<AddOrderItemDto> OrderItems { get; set; }
}