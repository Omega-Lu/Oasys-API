using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OaSys.API.Migrations
{
    public partial class Productenlongcontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CONTACT_NUMBER",
                table: "Supplier",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ALT_NUMBER",
                table: "Supplier",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRODUCT_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QUANTITY_ON_HAND = table.Column<int>(type: "int", nullable: false),
                    COST_PRICE = table.Column<float>(type: "real", nullable: false),
                    SELLING_PRICE = table.Column<float>(type: "real", nullable: false),
                    REORDER_LIMIT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.PRODUCT_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "CONTACT_NUMBER",
                table: "Supplier",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ALT_NUMBER",
                table: "Supplier",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
