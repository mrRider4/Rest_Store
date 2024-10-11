using Microsoft.EntityFrameworkCore;
using Store.Entities.Customers;
using Store.Entities.OrderItem;
using Store.Entities.Orders;
using Store.Entities.Products;
using Store.Services.Customers.Contracts;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Products.Contracts.Dtos;

namespace Store.Persistance.EF.Customers;

public class EFCustomerRepository : CustomerRepository
{
    private readonly EFDataContext _context;

    public EFCustomerRepository(EFDataContext context)
    {
        _context = context;
    }

    public async Task<bool> IsExistByPhoneNumber(string phoneNumber)
    {
        return await _context.Set<Customer>()
            .AnyAsync(_ => _.PhoneNumber == phoneNumber);
    }

    public async Task Add(Customer customer)
    {
        await _context.Set<Customer>().AddAsync(customer);
    }

    public async Task<List<GetCustomerDto>> GetAll(string? search)
    {
        var query = _context.Set<Customer>()
            .Select(_ => new GetCustomerDto()
            {
                Id = _.Id,
                Name = _.Name,
                PhoneNumber = _.PhoneNumber
            });
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(_ =>
                _.Name.Contains(search) || _.PhoneNumber.Contains(search));
        }

        return await query.ToListAsync();
    }

    public async Task<List<GetCustomerOrderDto>> GetOrdersById(int id)
    {
        Customer customer = await GetById(id);

        var query =
            (
                from order in _context.Set<Order>()
                where order.CustomerId == id
                join item in _context.Set<OrderItem>()
                    on order.Id equals item.OrderId
                join product in _context.Set<Product>()
                    on item.ProductId equals product.Id
                select new
                {
                    OrderId = order.Id,
                    TotalItemPrice = product.Price * item.Count,
                    PurcaseInvoice =
                        $"ProductId : {item.ProductId}\t" +
                        $"ProductName : {product.Name}\t" +
                        $"Count : {item.Count}\t" +
                        $"Price : {product.Price}\t" +
                        $"TotalPrice : {product.Price * item.Count}"
                })
            .GroupBy(_ => _.OrderId)
            .Select(_ => new GetCustomerOrderDto()
            {
                CustomerId = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                OrderId = _.Key,
                TotalPrice = _.Sum(_ => _.TotalItemPrice),
                PurchaseInvoice = string.Join("\n",
                    _.Select(_ => _.PurcaseInvoice).ToList())
            });
        return await query.ToListAsync();
    }

    public async Task<bool> IsExistById(int id)
    {
        return await _context.Set<Customer>().AnyAsync(_ => _.Id == id);
    }

    public async Task<Customer> GetById(int id)
    {
        return await _context.Set<Customer>().SingleAsync(_ => _.Id == id);
    }
}