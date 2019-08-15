using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Entities.Migrations
{
    public partial class CustomerTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCustomer",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_idCustomer",
                table: "Tickets",
                column: "idCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Customers_idCustomer",
                table: "Tickets",
                column: "idCustomer",
                principalTable: "Customers",
                principalColumn: "idCustomer",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Customers_idCustomer",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_idCustomer",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "idCustomer",
                table: "Tickets");
        }
    }
}
