

using Store.Applications.CreateOrder.Contracts.Dtos;
using Store.Applications.CreateOrderWithNewCustomer.Contracts;
using Store.Applications.CreateOrderWithNewCustomer.Contracts.Dtos;
using Store.Services;
using Store.Services.Customers.Contracts;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.OrderItems.Contracts;
using Store.Services.Orders.Contracts;
using Store.Services.Products.Contracts;

namespace Store.Applications.CreateOrderWithNewCustomer;

public class CreateOrderWithNewCustomerCommandHandler:CreateOrderWithNewCustomerHandler
{
    private readonly UnitOfWork _context;
    private readonly OrdersService _orderService;
    private readonly OrderItemsService _orderItemsService;
    private readonly CustomersService _customersService;
    
    private readonly ProductsService _productService;

    public CreateOrderWithNewCustomerCommandHandler(
        UnitOfWork context,
        OrdersService orderService,
        OrderItemsService orderItemsService,
        ProductsService productService,
        CustomersService customersService)
    {
        _context = context;
        _orderService = orderService;
        _orderItemsService = orderItemsService;
        _productService = productService;
        _customersService = customersService;
    }


    public async Task<GetCreateOrderresultDto> Create(AddOrderWithNewCustomer dto)
    {
        
        try
        {
            await _context.Begin();
            AddCustomerDto addCustomerDto = new AddCustomerDto()
            {
                Name = dto.Customer.Name,
                PhoneNumber = dto.Customer.PhoneNumber
            };
            int customerId = await _customersService.Add(addCustomerDto);
            int orderId= await _orderService.Add(customerId);
            await _productService.CheckProductListInventory(dto.OrderItems);
            var totalPrice=await _orderItemsService.AddAll(orderId,dto.OrderItems);
            
            await _context.Commit();
            
            var result = new GetCreateOrderresultDto()
            {
                CustomerId = customerId,
                OrderId = orderId,
                TotalPrice = totalPrice
            };
            return result;
        }
        catch (Exception e)
        {
            await _context.RollBack();
            throw e;
        }
        
    }
}