using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.Orders;

namespace Store.Persistance.EF.Orders;

public class OrderEntityMap:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> _)
    {
        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).UseIdentityColumn();
        _.Property(_ => _.CustomerId).IsRequired();
    }
}