using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OaSys.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Employee_ID",
                table: "Stocktake",
                newName: "EMPLOYEE_ID");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Stocktake",
                newName: "DATE");

            migrationBuilder.RenameColumn(
                name: "StockTake_ID",
                table: "Stocktake",
                newName: "STOCKTAKE_ID");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "Sales",
                newName: "USER_ID");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Sales",
                newName: "TOTAL");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sales",
                newName: "DATE");

            migrationBuilder.RenameColumn(
                name: "Customer_Account_ID",
                table: "Sales",
                newName: "CUSTOMER_ACCOUNT_ID");

            migrationBuilder.RenameColumn(
                name: "Sale_ID",
                table: "Sales",
                newName: "SALE_ID");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "Return",
                newName: "REASON");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Return",
                newName: "DATE");

            migrationBuilder.RenameColumn(
                name: "Return_ID",
                table: "Return",
                newName: "RETURN_ID");

            migrationBuilder.RenameColumn(
                name: "Date_Received",
                table: "Order",
                newName: "DATE_RECEIVED");

            migrationBuilder.RenameColumn(
                name: "Date_Placed",
                table: "Order",
                newName: "DATE_PLACED");

            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    Audit_Log_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    FUNCTION_USED = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.Audit_Log_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.RenameColumn(
                name: "EMPLOYEE_ID",
                table: "Stocktake",
                newName: "Employee_ID");

            migrationBuilder.RenameColumn(
                name: "DATE",
                table: "Stocktake",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "STOCKTAKE_ID",
                table: "Stocktake",
                newName: "StockTake_ID");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "Sales",
                newName: "User_ID");

            migrationBuilder.RenameColumn(
                name: "TOTAL",
                table: "Sales",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "DATE",
                table: "Sales",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CUSTOMER_ACCOUNT_ID",
                table: "Sales",
                newName: "Customer_Account_ID");

            migrationBuilder.RenameColumn(
                name: "SALE_ID",
                table: "Sales",
                newName: "Sale_ID");

            migrationBuilder.RenameColumn(
                name: "REASON",
                table: "Return",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "DATE",
                table: "Return",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "RETURN_ID",
                table: "Return",
                newName: "Return_ID");

            migrationBuilder.RenameColumn(
                name: "DATE_RECEIVED",
                table: "Order",
                newName: "Date_Received");

            migrationBuilder.RenameColumn(
                name: "DATE_PLACED",
                table: "Order",
                newName: "Date_Placed");
        }
    }
}
