using Store.Entities.OrderItem;
using Store.Services.OrderItems.Contracts;

namespace Store.Services.OrderItems;

public class OrderItemAppService:OrderItemsService
{
    private readonly UnitOfWork _context;
    private readonly OrderItemRepository _repository;

    public OrderItemAppService(
        UnitOfWork context,
        OrderItemRepository repository)
    {
        _context = context;
        _repository = repository;
    }

   
}