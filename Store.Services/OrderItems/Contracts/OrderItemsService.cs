using Store.Services.OrderItems.Contracts.Dtos;

namespace Store.Services.OrderItems.Contracts;

public interface OrderItemsService
{
    Task<decimal> AddAll(int orderId, List<AddOrderItemDto> dtoOrderItems);
}