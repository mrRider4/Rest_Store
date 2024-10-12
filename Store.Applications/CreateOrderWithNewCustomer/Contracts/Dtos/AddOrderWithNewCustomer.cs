using Store.Services.Customers.Contracts.Dtos;
using Store.Services.OrderItems.Contracts.Dtos;

namespace Store.Applications.CreateOrderWithNewCustomer.Contracts.Dtos;

public class AddOrderWithNewCustomer
{
    public AddCustomerDto Customer { get; set; }
    public List<AddOrderItemDto> OrderItems { get; set; }
}