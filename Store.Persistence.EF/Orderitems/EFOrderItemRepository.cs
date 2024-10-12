using Microsoft.EntityFrameworkCore;
using Store.Entities.OrderItem;
using Store.Services.OrderItems.Contracts;

namespace Store.Persistance.EF.Orderitems;

public class EFOrderItemRepository:OrderItemRepository
{
    private readonly EFDataContext _context;

    public EFOrderItemRepository(EFDataContext context)
    {
        _context = context;
    }

    public async Task<OrderItem> GetById(int id)
    {
        return await _context.Set<OrderItem>().SingleAsync(_ => _.Id == id);
    }

    public async Task Add(OrderItem orderItem)
    {
        await _context.AddAsync(orderItem);
    }
}