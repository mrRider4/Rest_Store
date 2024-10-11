namespace Store.Services.Customers.Contracts.Dtos;

public class GetCustomerOrderDto
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public int OrderId { get; set; }
    public string PurchaseInvoice { get; set; }
    public decimal TotalPrice { get; set; }
}