using Store.Services.Customers.Contracts.Dtos;

namespace Store.Services.Customers.Contracts;

public interface CustomersService
{
    Task<int> Add(AddCustomerDto dto);
    void NameValidation(string name);
    Task PhoneNumberValidation(string PhoneNumber);
    Task<List<GetCustomerDto>> GetAll(string? search);
    Task<List<GetCustomerOrderDto>> GetOrdersById(int id);
}