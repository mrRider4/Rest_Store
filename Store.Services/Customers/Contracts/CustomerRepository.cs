using Store.Entities.Customers;
using Store.Services.Customers.Contracts.Dtos;

namespace Store.Services.Customers.Contracts;

public interface CustomerRepository
{
    Task<bool> IsExistByPhoneNumber(string phoneNumber);
    Task Add(Customer customer);
    Task<List<GetCustomerDto>> GetAll(string? search);
    Task<List<GetCustomerOrderDto>> GetOrdersById(int id);
    Task<bool> IsExistById(int id);
    Task<Customer> GetById(int id);
}