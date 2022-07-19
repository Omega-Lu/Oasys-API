using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OaSys.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMPLOYEE_ID_NUMBER = table.Column<long>(type: "bigint", nullable: false),
                    PROVINCE_ID = table.Column<int>(type: "int", nullable: false),
                    EMPLOYEE_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    EMPLOYEE_STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    WARNING_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTACT_NUMBER = table.Column<long>(type: "bigint", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EMPLOYEE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Type",
                columns: table => new
                {
                    EMPLOYEE_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ROLE_ID = table.Column<int>(type: "int", nullable: false),
                    POSITION_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Type", x => x.EMPLOYEE_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    RATE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RATE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RATE_AMOUNT = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.RATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ROLE_ID = table.Column<int>(type: "int", nullable: false),
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false),
                    USER_STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USER_PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Warning",
                columns: table => new
                {
                    WARNING_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WARINING_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WARNING_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    REASON = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warning", x => x.WARNING_ID);
                });

            migrationBuilder.CreateTable(
                name: "Warning_Type",
                columns: table => new
                {
                    WARNING_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warning_Type", x => x.WARNING_TYPE_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Employee_Type");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Warning");

            migrationBuilder.DropTable(
                name: "Warning_Type");
        }
    }
}
