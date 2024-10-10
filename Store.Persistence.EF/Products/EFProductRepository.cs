using Microsoft.EntityFrameworkCore;
using Store.Entities.Products;
using Store.Services.Products.Contracts;
using Store.Services.Products.Contracts.Dtos;

namespace Store.Persistance.EF.Products;

public class EFProductRepository : ProductRepository
{
    private readonly EFDataContext _context;

    public EFProductRepository(EFDataContext context)
    {
        _context = context;
    }

    public async Task<bool> IsExistByName(string name)
    {
        return await _context.Set<Product>().AnyAsync(_ => _.Name == name);
    }

    public async Task Add(Product product)
    {
        await _context.Set<Product>().AddAsync(product);
    }

    public async Task<List<GetProductDto>> GetAll(string? name = null)
    {
        var query = _context.Set<Product>().Select(_ => new GetProductDto()
        {
            Id = _.Id,
            Name = _.Name,
            Count = _.Count,
            Price = _.Price
        });
        if (name != null)
        {
            query = query.Where(_ => _.Name.Contains(name));
        }

        return await query.ToListAsync();
    }

    public async Task<bool> IsExistById(int id)
    {
        return await _context.Set<Product>().AnyAsync(_ => _.Id == id);
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.Set<Product>().SingleAsync(_ => _.Id == id);
    }

    public void Delete(Product product)
    {
        _context.Set<Product>().Remove(product);
    }
}