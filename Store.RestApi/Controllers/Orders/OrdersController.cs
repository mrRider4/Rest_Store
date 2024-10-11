using Microsoft.AspNetCore.Mvc;
using Store.Applications.CreateOrder.Contracts;
using Store.Applications.CreateOrder.Contracts.Dtos;
using Store.Services.Orders.Contracts;
using Store.Services.Products.Contracts.Dtos;

namespace Store.RestApi.Controllers.Orders;
[Route("api/orders")]
[ApiController]
public class OrdersController:ControllerBase
{
    private readonly OrdersService _service;
    private readonly CreateOrderHandler _createOrderHandler;

    public OrdersController(
        OrdersService service,
        CreateOrderHandler createOrderHandler)
    {
        _service = service;
        _createOrderHandler = createOrderHandler;
    }


    [HttpPost]
    public async Task Create([FromQuery] AddOrderDto dto)
    {
        await _createOrderHandler.Create(dto);
    }
    
}