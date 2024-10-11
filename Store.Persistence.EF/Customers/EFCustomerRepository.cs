using Microsoft.EntityFrameworkCore;
using Store.Entities.Customers;
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
}