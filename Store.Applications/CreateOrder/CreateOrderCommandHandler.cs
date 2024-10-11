using Store.Applications.CreateOrder.Contracts;
using Store.Applications.CreateOrder.Contracts.Dtos;
using Store.Services;
using Store.Services.Customers.Contracts;
using Store.Services.OrderItems.Contracts;
using Store.Services.Orders.Contracts;
using Store.Services.Products.Contracts;

namespace Store.Applications.CreateOrder;

public class CreateOrderCommandHandler : CreateOrderHandler
{
    private readonly UnitOfWork _context;
    private readonly OrdersService _orderService;
    private readonly OrderItemsService _orderItemsService;
    private readonly CustomersService _customersService;
    private readonly ProductsServise _productServise;

    public CreateOrderCommandHandler(
        UnitOfWork context,
        OrdersService orderService,
        OrderItemsService orderItemsService,
        CustomersService customersService,
        ProductsServise productServise)
    {
        _context = context;
        _orderService = orderService;
        _orderItemsService = orderItemsService;
        _customersService = customersService;
        _productServise = productServise;
    }


    public async Task Create(AddOrderDto dto)
    {
        
        try
        {
            await _context.Begin();
            await _customersService.IsExistById(dto.CustomerId);
            string inventoryResult = "";
            foreach (var item in dto.OrderItems)
            {
                inventoryResult +=
                    await _productServise.CheckProductInventory
                        (item.ProductId, item.Count);
            }

            if (!string.IsNullOrEmpty(inventoryResult))
            {
                throw new Exception(
                    "There is problem with product count !!!\n" +
                    inventoryResult);
            }
            
            //TODO ...This Story Continues...!!! 
            
        }
        catch (Exception e)
        {
            await _context.RollBack();
            throw e;
        }
        
    }
}