using Store.Services.OrderItems.Contracts;

namespace Store.Persistance.EF.Orderitems;

public class EFOrderItemRepository:OrderItemRepository
{
    private readonly EFDataContext _context;

    public EFOrderItemRepository(EFDataContext context)
    {
        _context = context;
    }
}