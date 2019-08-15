using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Entities.Migrations
{
    public partial class historyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dtAssigned",
                table: "TicketHistories");

            migrationBuilder.AddColumn<DateTime>(
                name: "dtChanged",
                table: "TicketHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Customers_nuCustomer",
                table: "Customers",
                column: "nuCustomer",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_nuCustomer",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "dtChanged",
                table: "TicketHistories");

            migrationBuilder.AddColumn<DateTime>(
                name: "dtAssigned",
                table: "TicketHistories",
                nullable: true);
        }
    }
}
