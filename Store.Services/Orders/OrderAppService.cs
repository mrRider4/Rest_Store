using Store.Entities.Orders;
using Store.Services.Customers.Contracts;
using Store.Services.Orders.Contracts;
using Store.Services.Orders.Contracts.Dtos;

namespace Store.Services.Orders;

public class OrderAppService:OrdersService
{
    private readonly UnitOfWork _context;
    private readonly OrderRepository _repository;
    private readonly CustomerRepository _customerRepository;

    public OrderAppService(
        UnitOfWork context,
        OrderRepository repository,
        CustomerRepository customerRepository)
    {
        _context = context;
        _repository = repository;
        _customerRepository = customerRepository;
    }

    public async Task<int> Add(int customerId)
    {
        if (!await _customerRepository.IsExistById(customerId))
        {
            throw new Exception("Customer not found");
        }
        
        Order order = new Order()
        {
            CustomerId = customerId
        };
        await _repository.Add(order);
        await _context.Save();
        return order.Id;
    }

    public async Task<List<GetOrderDto>> GetAll()
    {
        return await _repository.GetAll();
    }
}