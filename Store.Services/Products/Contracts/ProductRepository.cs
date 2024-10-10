using Store.Entities.Products;
using Store.Services.Products.Contracts.Dtos;

namespace Store.Services.Products.Contracts;

public interface ProductRepository
{
    Task<bool> IsExistByName(string name);
    Task Add(Product product);
    Task<List<GetProductDto>> GetAll(string? name=null);

    Task<bool> IsExistById(int id);
    Task<Product> GetById(int id);
    void Delete(Product product);
}