using Store.Entities.OrderItem;
using Store.Entities.Products;
using Store.Services.Products.Contracts;
using Store.Services.Products.Contracts.Dtos;


namespace Store.Services.Products;

public class ProductAppService : ProductsServise
{
    private readonly UnitOfWork _context;
    private readonly ProductRepository _repository;

    public ProductAppService(
        UnitOfWork context,
        ProductRepository repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<int> Add(AddProductDto dto)
    {
        await ProductNameValidation(dto.Name);
        ProductPriceValidation(dto.Price);
        ProductCountValidation(dto.Count);
        Product product = new Product()
        {
            Name = dto.Name,
            Price = dto.Price,
            Count = dto.Count
        };
        await _repository.Add(product);
        await _context.Save();
        return product.Id;
    }

    public async Task<List<GetProductDto>> GetAll(string? name = null)
    {
        return await _repository.GetAll(name);
    }

    public async Task<GetProductDto> Update(PutProductDto dto)
    {
        await ThrowExceptionIfNotExistById(dto.Id);
        if (!string.IsNullOrEmpty(dto.Name))
            await ProductNameValidation(dto.Name);
        if (dto.Price != null) ProductPriceValidation((decimal)dto.Price);
        if (dto.Count != null) ProductCountValidation((int)dto.Count);

        var product = await _repository.GetById(dto.Id);
        product.Name = dto.Name ?? product.Name;
        product.Count = dto.Count ?? product.Count;
        product.Price = dto.Price ?? product.Price;

        await _context.Save();

        return new GetProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Count = product.Count,
            Price = product.Price
        };
    }

    public async Task DeleteById(int id)
    {
        if (!await _repository.IsExistById(id))
        {
            throw new Exception("Product not found !!!");
        }

        Product product = await _repository.GetById(id);
        _repository.Delete(product);
        await _context.Save();
    }

    public async Task ThrowExceptionIfNotExistById(int id)
    {
        if (!await _repository.IsExistById(id))
        {
            throw new Exception("Product not Exist !!!");
        }
    }

    public async Task ProductNameValidation(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Length > 100)
        {
            throw new Exception(
                "This product name is invalid!!! (must have <1> to <100> characters...)");
        }

        if (await _repository.IsExistByName(name))
        {
            throw new Exception("This product already exist...");
        }
    }

    public void ProductCountValidation(int count)
    {
        if (count < 0)
        {
            throw new Exception(
                "Product count is invalid to set !!!\n(min = 0)");
        }
    }

    public void ProductPriceValidation(decimal price)
    {
        if (price <= 0)
        {
            throw new Exception(
                "Product count is invalid to set !!!\n(min = 1)");
        }
    }

    public async Task<string> CheckProductInventory(int id, int count)
    {
        string result = "";
        Product product = await _repository.GetById(id);
        if (product.Count < count)
        {
            result += $"Product name : {product.Name}" +
                      $"product Id : {id}\t" +
                      $"Ordered count : {count}\t" +
                      $"Available count : {product.Count}";
        }

        return result;
    }
}