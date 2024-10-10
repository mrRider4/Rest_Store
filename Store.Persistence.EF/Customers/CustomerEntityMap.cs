using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.Customers;

namespace Store.Persistance.EF.Customers;

public class CustomerEntityMap:IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> _)
    {
        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).UseIdentityColumn();
        _.Property(_ => _.Name).IsRequired().HasMaxLength(200);
        _.Property(_ => _.PhoneNumber).IsRequired().HasMaxLength(10);
    }
}