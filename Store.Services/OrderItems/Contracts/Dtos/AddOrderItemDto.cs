namespace Store.Services.OrderItems.Contracts.Dtos;

public class AddOrderItemDto
{
    public const string Note = "If dont enter count , ";
    public int ProductId { get; set; }
    public int Count { get; set; } 
}