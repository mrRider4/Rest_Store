using Store.Entities.OrderItem;
using Store.Entities.Products;
using Store.Services.OrderItems.Contracts;
using Store.Services.OrderItems.Contracts.Dtos;
using Store.Services.Products.Contracts;

namespace Store.Services.OrderItems;

public class OrderItemAppService : OrderItemsService
{
    private readonly UnitOfWork _context;
    private readonly OrderItemRepository _repository;
    private readonly ProductRepository _productRepository;

    public OrderItemAppService(
        UnitOfWork context,
        OrderItemRepository repository,
        ProductRepository productRepository)
    {
        _context = context;
        _repository = repository;
        _productRepository = productRepository;
    }


    public async Task<decimal> AddAll(int orderId,
        List<AddOrderItemDto> dtoOrderItems)
    {
        if (!dtoOrderItems.Any())
        {
            throw new Exception("There is no order item to add !!!");
        }
        decimal totalPrice = 0;
        foreach (var item in dtoOrderItems)
        {
            if (item.Count<1)
            {
                item.Count = 1;
            }
            OrderItem orderItem = new OrderItem()
            {
                OrderId = orderId,
                ProductId = item.ProductId,
                Count = item.Count
            };
            await _repository.Add(orderItem);
            Product product = await _productRepository.GetById(item.ProductId);
            product.Count = product.Count - item.Count;
            totalPrice += product.Price * item.Count;
        }
            await _context.Save();

        return totalPrice;
    }
}