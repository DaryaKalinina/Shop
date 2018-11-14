using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class add_pole_IsItPayed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsItPaid",
                table: "OrderItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsItPayed",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsItPayed",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsItPaid",
                table: "OrderItems",
                nullable: false,
                defaultValue: false);
        }
    }
}
