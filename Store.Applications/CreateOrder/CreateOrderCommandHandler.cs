﻿using Store.Applications.CreateOrder.Contracts;
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
    
    private readonly ProductsService _productService;

    public CreateOrderCommandHandler(
        UnitOfWork context,
        OrdersService orderService,
        OrderItemsService orderItemsService,
        ProductsService productService)
    {
        _context = context;
        _orderService = orderService;
        _orderItemsService = orderItemsService;
       
        _productService = productService;
    }


    public async Task<GetCreateOrderresultDto> Create(AddOrderDto dto)
    {
        
        try
        {
            await _context.Begin();
            int orderId= await _orderService.Add(dto.CustomerId);
            // await _customersService.IsExistById(dto.CustomerId);
            await _productService.CheckProductListInventory(dto.OrderItems);
            // string inventoryResult = "";
            // foreach (var item in dto.OrderItems)
            // {
            //     inventoryResult +=
            //         await _productService.CheckProductInventory
            //             (item.ProductId, item.Count);
            // }
            //
            // if (!string.IsNullOrEmpty(inventoryResult))
            // {
            //     throw new Exception(
            //         "There is problem with product count !!!\n" +
            //         inventoryResult);
            // }
            //
           var totalPrice=await _orderItemsService.AddAll(orderId,dto.OrderItems);
            await _context.Commit();
            var result = new GetCreateOrderresultDto()
            {
                CustomerId = dto.CustomerId,
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