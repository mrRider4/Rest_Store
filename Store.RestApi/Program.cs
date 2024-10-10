using Microsoft.EntityFrameworkCore;
using Store.Persistance.EF;
using Store.Persistance.EF.Customers;
using Store.Persistance.EF.Orderitems;
using Store.Persistance.EF.Orders;
using Store.Persistance.EF.Products;
using Store.Services;
using Store.Services.Customers;
using Store.Services.Customers.Contracts;
using Store.Services.OrderItems;
using Store.Services.OrderItems.Contracts;
using Store.Services.Orders;
using Store.Services.Orders.Contracts;
using Store.Services.Products;
using Store.Services.Products.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EFDataContext>
(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"
        )));
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();

builder.Services.AddScoped<ProductRepository, EFProductRepository>();
builder.Services.AddScoped<ProductsServise, ProductAppService>();

builder.Services.AddScoped<CustomerRepository, EFCustomerRepository>();
builder.Services.AddScoped<CustomersService, CustomerAppService>();

builder.Services.AddScoped<OrderRepository, EFOrderRepository>();
builder.Services.AddScoped<OrdersService, OrderAppService>();

builder.Services.AddScoped<OrderItemRepository, EFOrderItemRepository>();
builder.Services.AddScoped<OrderItemsService, OrderItemAppService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();