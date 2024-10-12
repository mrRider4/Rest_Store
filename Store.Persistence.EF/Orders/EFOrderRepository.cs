using Microsoft.EntityFrameworkCore;
using Store.Entities.Customers;
using Store.Entities.OrderItem;
using Store.Entities.Orders;
using Store.Entities.Products;
using Store.Services.Orders.Contracts;
using Store.Services.Orders.Contracts.Dtos;

namespace Store.Persistance.EF.Orders;

public class EFOrderRepository : OrderRepository
{
    private readonly EFDataContext _context;

    public EFOrderRepository(EFDataContext context)
    {
        _context = context;
    }

    public async Task<bool> IsExistByCustomerId(int customerId)
    {
        return await _context.Set<Order>()
            .AnyAsync(_ => _.CustomerId == customerId);
    }

    public async Task Add(Order order)
    {
        await _context.Set<Order>().AddAsync(order);
    }

    public async Task<List<GetOrderDto>> GetAll()
    {
        var query =
            (from order in _context.Set<Order>()
                join customer in _context.Set<Customer>()
                    on order.CustomerId equals customer.Id
                join orderItem in _context.Set<OrderItem>()
                    on order.Id equals orderItem.OrderId
                join product in _context.Set<Product>()
                    on orderItem.ProductId equals product.Id
                select new
                {
                    Id = order.Id,
                    CustomerId = customer.Id,
                    TotalPrice = product.Price * orderItem.Count,
                    PurchaseInvoice = $"ProductId : {orderItem.ProductId}\t" +
                                      $"ProductName : {product.Name}\t" +
                                      $"Count : {orderItem.Count}\t" +
                                      $"Price : {product.Price}\t" +
                                      $"TotalPrice : {product.Price * orderItem.Count}"
                }).GroupBy(_ => _.Id).Select(_ => new GetOrderDto()
            {
                OrderId = _.Key,
                CustomerId = _.First().CustomerId,
                PurchaseInvoice = string.Join("\n",
                    _.Select(_ => _.PurchaseInvoice).ToList()),
                TotalPrice = _.Sum(_=>_.TotalPrice)
            });
        return await query.ToListAsync();
    }
}