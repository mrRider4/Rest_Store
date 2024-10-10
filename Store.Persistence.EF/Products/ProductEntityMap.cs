using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.Products;

namespace Store.Persistance.EF.Products;

public class ProductEntityMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> _)
    {
        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).UseIdentityColumn();
        _.Property(_ => _.Name).IsRequired().HasMaxLength(100);
        _.Property(_ => _.Price).IsRequired();
        _.Property(_ => _.Count).IsRequired();
    }
}