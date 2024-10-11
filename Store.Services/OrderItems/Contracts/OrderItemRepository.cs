using Store.Entities.OrderItem;

namespace Store.Services.OrderItems.Contracts;

public interface OrderItemRepository
{
    Task<OrderItem> GetById(int id);
}