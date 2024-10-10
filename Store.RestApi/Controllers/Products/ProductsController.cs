using Microsoft.AspNetCore.Mvc;
using Store.Services.Products.Contracts;
using Store.Services.Products.Contracts.Dtos;

namespace Store.RestApi.Controllers.Products;

[Route("api/Products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductsServise _servise;

    public ProductsController(ProductsServise service)
    {
        _servise = service;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] AddProductDto dto)
    {
        return await _servise.Add(dto);
    }

    [HttpGet("all-by-filter")]
    public async Task<List<GetProductDto>> GetAll([FromQuery] string? name)
    {
        return await _servise.GetAll(name);
    }

    [HttpDelete("by-id/{id}")]
    public async Task DeleteById([FromRoute] int id)
    {
        await _servise.DeleteById(id);
    }

    [HttpPut]
    public async Task<GetProductDto> Update([FromQuery] PutProductDto dto)
    {
        return await _servise.Update(dto);
    }
}