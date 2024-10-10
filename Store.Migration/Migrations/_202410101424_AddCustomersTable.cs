using FluentMigrator;

namespace Clinic.Migrations.Migrations;
[Migration(202410101424)]
public class _202410101424_AddCustomersTable:Migration
{
    public override void Up()
    {
        Create.Table("Customers")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey()
            .WithColumn("Name").AsString(200).NotNullable()
            .WithColumn("PhoneNumber").AsString(10).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Customers");
    }
}