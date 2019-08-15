using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Entities.Migrations
{
    public partial class staffuser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Staff_idStaff",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_idStaff",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "idStaff",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "idUser",
                table: "Staff",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_idUser",
                table: "Staff",
                column: "idUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_AspNetUsers_idUser",
                table: "Staff",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_AspNetUsers_idUser",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_idUser",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "idUser",
                table: "Staff");

            migrationBuilder.AddColumn<int>(
                name: "idStaff",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_idStaff",
                table: "AspNetUsers",
                column: "idStaff");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Staff_idStaff",
                table: "AspNetUsers",
                column: "idStaff",
                principalTable: "Staff",
                principalColumn: "idStaff",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
