using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OaSys.API.Migrations
{
    public partial class vatnumberlong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "VAT_NUMBER",
                table: "Supplier",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VAT_NUMBER",
                table: "Supplier",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
