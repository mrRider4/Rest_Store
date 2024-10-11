namespace Store.Services.Orders.Contracts;

public interface OrderRepository
{
    Task<bool> IsExistByCustomerId(int customerId);
}