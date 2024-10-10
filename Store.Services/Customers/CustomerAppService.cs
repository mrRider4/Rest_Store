
using Store.Services.Customers.Contracts;

namespace Store.Services.Customers;

public class CustomerAppService:CustomersService
{
    private readonly UnitOfWork _context;
    private readonly CustomerRepository _repository;

    public CustomerAppService(
        UnitOfWork context,
        CustomerRepository repository)
    {
        _context = context;
        _repository = repository;
    }
}