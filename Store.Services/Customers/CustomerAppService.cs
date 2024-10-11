using Store.Entities.Customers;
using Store.Services.Customers.Contracts;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Orders.Contracts;

namespace Store.Services.Customers;

public class CustomerAppService : CustomersService
{
    private readonly UnitOfWork _context;
    private readonly CustomerRepository _repository;
    private readonly OrderRepository _orderRepository;

    public CustomerAppService(
        UnitOfWork context,
        CustomerRepository repository,
        OrderRepository orderRepository)
    {
        _context = context;
        _repository = repository;
        _orderRepository = orderRepository;
    }

    public async Task<int> Add(AddCustomerDto dto)
    {
        NameValidation(dto.Name);
        await PhoneNumberValidation(dto.PhoneNumber);
        var customer = new Customer()
        {
            Name = dto.Name,
            PhoneNumber = dto.PhoneNumber
        };
        await _repository.Add(customer);
        await _context.Save();
        return customer.Id;
    }

    public void NameValidation(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Length > 200)
        {
            throw new Exception(
                "Invalid Name!!! (must have <1> to <200> characters...)");
        }
    }

    public async Task PhoneNumberValidation(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 10)
        {
            throw new Exception(
                "Invalid PhoneNumber!!! (must have <10> characters...)");
        }

        if (await _repository.IsExistByPhoneNumber(phoneNumber))
        {
            throw new Exception(
                "This customer already registered with this phone number...");
        }
    }

    public async Task<List<GetCustomerDto>> GetAll(string? search)
    {
        return await _repository.GetAll(search);
    }

    public async Task<List<GetCustomerOrderDto>> GetOrdersById(int id)
    {
        if (!await _repository.IsExistById(id))
            throw new Exception("Customer not found ...");

        if (!await _orderRepository.IsExistByCustomerId(id))
            throw new Exception("This customer has no orders yet ...");

        return await _repository.GetOrdersById(id);
    }
}