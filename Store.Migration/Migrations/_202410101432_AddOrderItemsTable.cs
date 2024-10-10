using FluentMigrator;

namespace Clinic.Migrations.Migrations;
[Migration(202410101432)]
public class _202410101432_AddOrderItemsTable:Migration
{
    public override void Up()
    {
        Create.Table("OrderItems")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey()
            .WithColumn("OrderId").AsInt32().NotNullable()
            .WithColumn("ProductId").AsInt32().NotNullable()
            .WithColumn("Count").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("OrderItems");
    }
}