using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Entities.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    idCountry = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nmCountry = table.Column<string>(maxLength: 70, nullable: false),
                    abbrevationCountry = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.idCountry);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatuses",
                columns: table => new
                {
                    idTicketStatus = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deTicketStatus = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatuses", x => x.idTicketStatus);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    idAddress = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    street = table.Column<string>(maxLength: 100, nullable: false),
                    disctrict = table.Column<string>(maxLength: 100, nullable: true),
                    nuAddress = table.Column<string>(maxLength: 10, nullable: false),
                    idCountry = table.Column<int>(nullable: false),
                    cityAddress = table.Column<string>(maxLength: 100, nullable: true),
                    zipAddress = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.idAddress);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_idCountry",
                        column: x => x.idCountry,
                        principalTable: "Countries",
                        principalColumn: "idCountry",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    idCustomer = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nmCustomer = table.Column<string>(maxLength: 150, nullable: false),
                    nuPhone = table.Column<string>(maxLength: 20, nullable: false),
                    adEmail = table.Column<string>(maxLength: 100, nullable: false),
                    nuCustomer = table.Column<int>(nullable: false),
                    idAddress = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.idCustomer);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_idAddress",
                        column: x => x.idAddress,
                        principalTable: "Addresses",
                        principalColumn: "idAddress",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    idStore = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nmStore = table.Column<string>(maxLength: 100, nullable: false),
                    idCountry = table.Column<int>(nullable: false),
                    idAddress = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.idStore);
                    table.ForeignKey(
                        name: "FK_Stores_Addresses_idAddress",
                        column: x => x.idAddress,
                        principalTable: "Addresses",
                        principalColumn: "idAddress",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stores_Countries_idCountry",
                        column: x => x.idCountry,
                        principalTable: "Countries",
                        principalColumn: "idCountry",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    idStaff = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nameStaff = table.Column<string>(maxLength: 150, nullable: false),
                    nuPhone = table.Column<string>(nullable: true),
                    adEmail = table.Column<string>(nullable: false),
                    adEmailPersonal = table.Column<string>(nullable: true),
                    dtRegistration = table.Column<DateTime>(nullable: false),
                    isAdmin = table.Column<bool>(nullable: false),
                    idStore = table.Column<int>(nullable: false),
                    idAddress = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.idStaff);
                    table.ForeignKey(
                        name: "FK_Staff_Addresses_idAddress",
                        column: x => x.idAddress,
                        principalTable: "Addresses",
                        principalColumn: "idAddress",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_Stores_idStore",
                        column: x => x.idStore,
                        principalTable: "Stores",
                        principalColumn: "idStore",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    idTicket = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    deTicket = table.Column<string>(nullable: false),
                    dtOpening = table.Column<DateTime>(nullable: false),
                    dtClosing = table.Column<DateTime>(nullable: false),
                    dtDue = table.Column<DateTime>(nullable: false),
                    idStaffAssignedTo = table.Column<int>(nullable: false),
                    idTicketStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.idTicket);
                    table.ForeignKey(
                        name: "FK_Tickets_Staff_idStaffAssignedTo",
                        column: x => x.idStaffAssignedTo,
                        principalTable: "Staff",
                        principalColumn: "idStaff",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketStatuses_idTicketStatus",
                        column: x => x.idTicketStatus,
                        principalTable: "TicketStatuses",
                        principalColumn: "idTicketStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketHistories",
                columns: table => new
                {
                    idTicketHistory = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idTicket = table.Column<int>(nullable: false),
                    idStaffAssigned = table.Column<int>(nullable: false),
                    idTicketStatus = table.Column<int>(nullable: false),
                    idStaffAssigns = table.Column<int>(nullable: false),
                    dtAssigned = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketHistories", x => x.idTicketHistory);
                    table.ForeignKey(
                        name: "FK_TicketHistories_Staff_idStaffAssigned",
                        column: x => x.idStaffAssigned,
                        principalTable: "Staff",
                        principalColumn: "idStaff",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketHistories_Staff_idStaffAssigns",
                        column: x => x.idStaffAssigns,
                        principalTable: "Staff",
                        principalColumn: "idStaff",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketHistories_Tickets_idTicket",
                        column: x => x.idTicket,
                        principalTable: "Tickets",
                        principalColumn: "idTicket",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketHistories_TicketStatuses_idTicketStatus",
                        column: x => x.idTicketStatus,
                        principalTable: "TicketStatuses",
                        principalColumn: "idTicketStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_idCountry",
                table: "Addresses",
                column: "idCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_adEmail",
                table: "Customers",
                column: "adEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_idAddress",
                table: "Customers",
                column: "idAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_adEmail",
                table: "Staff",
                column: "adEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_idAddress",
                table: "Staff",
                column: "idAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_idStore",
                table: "Staff",
                column: "idStore");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_idAddress",
                table: "Stores",
                column: "idAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_idCountry",
                table: "Stores",
                column: "idCountry");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_idStaffAssigned",
                table: "TicketHistories",
                column: "idStaffAssigned");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_idStaffAssigns",
                table: "TicketHistories",
                column: "idStaffAssigns");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_idTicket",
                table: "TicketHistories",
                column: "idTicket");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_idTicketStatus",
                table: "TicketHistories",
                column: "idTicketStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_idStaffAssignedTo",
                table: "Tickets",
                column: "idStaffAssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_idTicketStatus",
                table: "Tickets",
                column: "idTicketStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "TicketHistories");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "TicketStatuses");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
