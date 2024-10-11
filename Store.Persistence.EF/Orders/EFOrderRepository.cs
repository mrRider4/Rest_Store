using Microsoft.EntityFrameworkCore;
using Store.Entities.Orders;
using Store.Services.Orders.Contracts;

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
}