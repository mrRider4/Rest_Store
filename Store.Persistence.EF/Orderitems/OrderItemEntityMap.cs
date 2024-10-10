using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.OrderItem;

namespace Store.Persistance.EF.Orderitems;

public class OrderItemEntityMap:IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> _)
    {
        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).UseIdentityColumn();
        _.Property(_ => _.OrderId).IsRequired();
        _.Property(_ => _.ProductId).IsRequired();
        _.Property(_ => _.Count).IsRequired();
    }
}