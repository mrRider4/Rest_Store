using Store.Applications.CreateOrder.Contracts.Dtos;

namespace Store.Applications.CreateOrder.Contracts;

public interface CreateOrderHandler
{
    Task<GetCreateOrderresultDto> Create(AddOrderDto dto);
}