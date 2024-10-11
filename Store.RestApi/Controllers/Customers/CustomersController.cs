using Microsoft.AspNetCore.Mvc;
using Store.Services.Customers.Contracts;
using Store.Services.Customers.Contracts.Dtos;

namespace Store.RestApi.Controllers.Customers;

[Route("api/Customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly CustomersService _service;

    public CustomersController(CustomersService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<int> Create(AddCustomerDto dto)
    {
        return await _service.Add(dto);
    }

    [HttpGet("all-by-filter")]
    public async Task<List<GetCustomerDto>> GetAll([FromQuery] string? search)
    {
        var s = string.Join("\t","asd");
        return await _service.GetAll(search);
    }
}