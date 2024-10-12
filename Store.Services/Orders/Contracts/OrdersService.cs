using Store.Services.Orders.Contracts.Dtos;

namespace Store.Services.Orders.Contracts;

public interface OrdersService
{
    Task<int> Add(int customerId);
    Task<List<GetOrderDto>> GetAll();
}