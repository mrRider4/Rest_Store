using Microsoft.AspNetCore.Mvc;
using Store.Services.Products.Contracts;
using Store.Services.Products.Contracts.Dtos;

namespace Store.RestApi.Controllers.Products;

[Route("api/Products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _service;

    public ProductsController(ProductsService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] AddProductDto dto)
    {
        return await _service.Add(dto);
    }

    [HttpGet("all-by-filter")]
    public async Task<List<GetProductDto>> GetAll([FromQuery] string? name)
    {
        return await _service.GetAll(name);
    }

    [HttpDelete("by-id/{id}")]
    public async Task DeleteById([FromRoute] int id)
    {
        await _service.DeleteById(id);
    }

    [HttpPut]
    public async Task<GetProductDto> Update([FromQuery] PutProductDto dto)
    {
        return await _service.Update(dto);
    }
}