﻿namespace Store.Services.Products.Contracts.Dtos;

public class GetProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}