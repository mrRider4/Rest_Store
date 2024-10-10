using FluentMigrator;

namespace Clinic.Migrations.Migrations;
[Migration(202410101428)]
public class _202410101428_AddOrdersTable:Migration
{
    public override void Up()
    {
        Create.Table("Orders")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey()
            .WithColumn("CustomerId").AsInt32().NotNullable();

    }

    public override void Down()
    {
        Delete.Table("Orders");
    }
}