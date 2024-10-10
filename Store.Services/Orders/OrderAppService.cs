using Store.Services.Orders.Contracts;

namespace Store.Services.Orders;

public class OrderAppService:OrdersService
{
    private readonly UnitOfWork _context;
    private readonly OrderRepository _repository;

    public OrderAppService(
        UnitOfWork context,
        OrderRepository repository)
    {
        _context = context;
        _repository = repository;
    }
}