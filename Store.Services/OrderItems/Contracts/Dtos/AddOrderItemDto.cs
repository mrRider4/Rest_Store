namespace Store.Services.OrderItems.Contracts.Dtos;

public class AddOrderItemDto
{
    public int ProductId { get; set; }
    public int Count { get; set; }
}