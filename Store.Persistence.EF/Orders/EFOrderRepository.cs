using Store.Services.Orders.Contracts;

namespace Store.Persistance.EF.Orders;

public class EFOrderRepository : OrderRepository
{
    private readonly EFDataContext _context;

    public EFOrderRepository(EFDataContext context)
    {
        _context = context;
    }
}