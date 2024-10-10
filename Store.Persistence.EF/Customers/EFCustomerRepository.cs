using Store.Services.Customers.Contracts;

namespace Store.Persistance.EF.Customers;

public class EFCustomerRepository:CustomerRepository
{
    private readonly EFDataContext _context;

    public EFCustomerRepository(EFDataContext context)
    {
        _context = context;
    }
}