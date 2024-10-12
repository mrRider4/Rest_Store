using Store.Entities.Orders;
using Store.Services.Orders.Contracts.Dtos;

namespace Store.Services.Orders.Contracts;

public interface OrderRepository
{
    Task<bool> IsExistByCustomerId(int customerId);
    Task Add(Order order);
    Task<List<GetOrderDto>> GetAll();
}