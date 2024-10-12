using Microsoft.AspNetCore.Mvc;
using Store.Applications.CreateOrder.Contracts;
using Store.Applications.CreateOrder.Contracts.Dtos;
using Store.Applications.CreateOrderWithNewCustomer.Contracts;
using Store.Applications.CreateOrderWithNewCustomer.Contracts.Dtos;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Orders.Contracts;
using Store.Services.Orders.Contracts.Dtos;
using Store.Services.Products.Contracts.Dtos;

namespace Store.RestApi.Controllers.Orders;
[Route("api/orders")]
[ApiController]
public class OrdersController:ControllerBase
{
    private readonly OrdersService _service;
    private readonly CreateOrderHandler _orderHandler;
    private readonly CreateOrderWithNewCustomerHandler
        _orderWithNewCustomerHandler;

    public OrdersController(
        OrdersService service,
        CreateOrderHandler orderHandler,
        CreateOrderWithNewCustomerHandler orderWithNewCustomerHandler)
    {
        _service = service;
        _orderHandler = orderHandler;
        _orderWithNewCustomerHandler = orderWithNewCustomerHandler;
    }


    [HttpPost]
    public async Task<GetCreateOrderresultDto> Create([FromBody] AddOrderDto dto)
    {
        
       return await _orderHandler.Create(dto);
    }

    [HttpPost("add-customer-and-order")]
    public async Task<GetCreateOrderresultDto> CreatWithNewCustomer(
        [FromBody] AddOrderWithNewCustomer dto)
    {
        return await _orderWithNewCustomerHandler.Create(dto);
    }

    [HttpGet("all")]
    public async Task<List<GetOrderDto>> GetAll()
    {
       return await _service.GetAll();
    }
}