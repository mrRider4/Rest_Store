using Microsoft.EntityFrameworkCore;
using Store.Entities.Customers;
using Store.Entities.OrderItem;
using Store.Entities.Orders;
using Store.Entities.Products;
using Store.Persistance.EF.Products;

namespace Store.Persistance.EF;

public class EFDataContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public EFDataContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=Cloud4;Initial Catalog=DB_REST3_Store;User Id=CLOUD4;Password=21102110;TrustServerCertificate=true;");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductEntityMap)
            .Assembly);
    }
}