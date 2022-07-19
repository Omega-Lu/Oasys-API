using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OaSys.API.Migrations
{
    public partial class Customer_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_Account",
                columns: table => new
                {
                    CUSTOMER_ACCOUNT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCOUNT_STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    PROVINCE_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTACT_NUMBER = table.Column<long>(type: "bigint", nullable: false),
                    AMOUNT_OWING = table.Column<float>(type: "real", nullable: false),
                    CREDIT_LIMIT = table.Column<float>(type: "real", nullable: false),
                    REMINDER_MESSAGE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Account", x => x.CUSTOMER_ACCOUNT_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Account");
        }
    }
}
