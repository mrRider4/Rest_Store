using FluentMigrator;

namespace Clinic.Migrations.Migrations;
[Migration(202410101417)]
public class _202410101417_AddProductsTable:Migration
{
    public override void Up()
    {
        Create.Table("Products")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey()
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable()
            .WithColumn("Count").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Products");
    }
}