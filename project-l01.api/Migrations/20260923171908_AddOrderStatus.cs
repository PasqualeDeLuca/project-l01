using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_l01.Api.Migrations
{
    public partial class AddOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusTemp",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("""
                UPDATE orders
                SET "StatusTemp" =
                    CASE "Status"
                        WHEN 'Pending' THEN 0
                        WHEN 'Processing' THEN 1
                        WHEN 'Shipped' THEN 2
                        WHEN 'Completed' THEN 3
                        WHEN 'Cancelled' THEN 4
                        ELSE 0
                    END;
                """);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "StatusTemp",
                table: "orders",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusTemp",
                table: "orders",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql("""
                UPDATE orders
                SET "StatusTemp" =
                    CASE "Status"
                        WHEN 0 THEN 'Pending'
                        WHEN 1 THEN 'Processing'
                        WHEN 2 THEN 'Shipped'
                        WHEN 3 THEN 'Completed'
                        WHEN 4 THEN 'Cancelled'
                        ELSE 'Pending'
                    END;
                """);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "StatusTemp",
                table: "orders",
                newName: "Status");
        }
    }
}