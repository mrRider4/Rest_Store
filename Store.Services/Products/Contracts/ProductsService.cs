using Store.Services.OrderItems.Contracts.Dtos;
using Store.Services.Products.Contracts.Dtos;

namespace Store.Services.Products.Contracts;

public interface ProductsService
{
    Task<int> Add(AddProductDto dto); 
    Task ProductNameValidation(string name);
    Task<List<GetProductDto>> GetAll(string? name=null);
    Task DeleteById(int id);
    Task<GetProductDto> Update(PutProductDto dto);
    Task ThrowExceptionIfNotExistById(int id);
    void ProductCountValidation(int count);
    void ProductPriceValidation(decimal price);
    Task<string> CheckProductInventory(int id, int count);
    Task CheckProductListInventory(List<AddOrderItemDto> dtoList);
}