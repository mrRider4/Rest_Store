using Store.Applications.CreateOrder.Contracts.Dtos;
using Store.Applications.CreateOrderWithNewCustomer.Contracts.Dtos;

namespace Store.Applications.CreateOrderWithNewCustomer.Contracts;

public interface CreateOrderWithNewCustomerHandler
{
    Task<GetCreateOrderresultDto> Create(AddOrderWithNewCustomer dto);
}