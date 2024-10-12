namespace Store.Services.Orders.Contracts.Dtos;

public class GetOrderDto
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string PurchaseInvoice { get; set; }
    public decimal TotalPrice { get; set; }
}