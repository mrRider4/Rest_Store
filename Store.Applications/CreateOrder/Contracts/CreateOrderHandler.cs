using Store.Applications.CreateOrder.Contracts.Dtos;

namespace Store.Applications.CreateOrder.Contracts;

public interface CreateOrderHandler
{
    Task Create(AddOrderDto dto);
}