using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceComputer.Model.Migrations
{
    public partial class InitMark4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "total",
                table: "ShopCarts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total",
                table: "ShopCarts");
        }
    }
}
