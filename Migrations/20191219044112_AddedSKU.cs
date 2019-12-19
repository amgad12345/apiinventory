using Microsoft.EntityFrameworkCore.Migrations;

namespace apiinventory.Migrations
{
    public partial class AddedSKU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "sku",
                table: "Items",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sku",
                table: "Items");
        }
    }
}
