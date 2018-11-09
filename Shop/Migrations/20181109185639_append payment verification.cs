using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class appendpaymentverification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsItPaid",
                table: "OrderItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsItPaid",
                table: "OrderItems");
        }
    }
}
