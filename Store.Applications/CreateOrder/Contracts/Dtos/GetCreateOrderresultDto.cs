namespace Store.Applications.CreateOrder.Contracts.Dtos;

public class GetCreateOrderresultDto
{
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
    public decimal TotalPrice { get; set; }
}