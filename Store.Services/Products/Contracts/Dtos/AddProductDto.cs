namespace Store.Services.Products.Contracts.Dtos;

public class AddProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}