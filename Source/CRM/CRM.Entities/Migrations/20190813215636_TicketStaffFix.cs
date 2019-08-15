using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Entities.Migrations
{
    public partial class TicketStaffFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketHistories_Staff_idStaffAssigned",
                table: "TicketHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Staff_idStaffAssignedTo",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "idStaffAssignedTo",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "idStaffAssigned",
                table: "TicketHistories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TicketHistories_Staff_idStaffAssigned",
                table: "TicketHistories",
                column: "idStaffAssigned",
                principalTable: "Staff",
                principalColumn: "idStaff",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Staff_idStaffAssignedTo",
                table: "Tickets",
                column: "idStaffAssignedTo",
                principalTable: "Staff",
                principalColumn: "idStaff",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketHistories_Staff_idStaffAssigned",
                table: "TicketHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Staff_idStaffAssignedTo",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "idStaffAssignedTo",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idStaffAssigned",
                table: "TicketHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketHistories_Staff_idStaffAssigned",
                table: "TicketHistories",
                column: "idStaffAssigned",
                principalTable: "Staff",
                principalColumn: "idStaff",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Staff_idStaffAssignedTo",
                table: "Tickets",
                column: "idStaffAssignedTo",
                principalTable: "Staff",
                principalColumn: "idStaff",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
