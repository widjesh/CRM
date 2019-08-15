﻿// <auto-generated />
using System;
using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRM.Entities.Migrations
{
    [DbContext(typeof(CRMContext))]
    [Migration("20190813020908_staffuser3")]
    partial class staffuser3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CRM.Entities.Address", b =>
                {
                    b.Property<int>("idAddress")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("cityAddress")
                        .HasMaxLength(100);

                    b.Property<string>("disctrict")
                        .HasMaxLength(100);

                    b.Property<int>("idCountry");

                    b.Property<string>("nuAddress")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("street")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("zipAddress")
                        .HasMaxLength(15);

                    b.HasKey("idAddress");

                    b.HasIndex("idCountry");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CRM.Entities.Country", b =>
                {
                    b.Property<int>("idCountry")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("abbrevationCountry")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("nmCountry")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.HasKey("idCountry");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CRM.Entities.Customer", b =>
                {
                    b.Property<int>("idCustomer")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("adEmail")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("idAddress");

                    b.Property<string>("nmCustomer")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("nuCustomer");

                    b.Property<string>("nuPhone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("idCustomer");

                    b.HasIndex("adEmail")
                        .IsUnique();

                    b.HasIndex("idAddress");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CRM.Entities.Staff", b =>
                {
                    b.Property<int>("idStaff")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("adEmail")
                        .IsRequired();

                    b.Property<string>("adEmailPersonal");

                    b.Property<DateTime>("dtRegistration");

                    b.Property<int>("idAddress");

                    b.Property<int>("idStore");

                    b.Property<string>("idUser");

                    b.Property<bool>("isAdmin");

                    b.Property<string>("nameStaff")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("nuPhone");

                    b.HasKey("idStaff");

                    b.HasIndex("adEmail")
                        .IsUnique();

                    b.HasIndex("idAddress");

                    b.HasIndex("idStore");

                    b.HasIndex("idUser");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("CRM.Entities.Store", b =>
                {
                    b.Property<int>("idStore")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("idAddress");

                    b.Property<int>("idCountry");

                    b.Property<string>("nmStore")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("idStore");

                    b.HasIndex("idAddress");

                    b.HasIndex("idCountry");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("CRM.Entities.Ticket", b =>
                {
                    b.Property<int>("idTicket")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("deTicket")
                        .IsRequired();

                    b.Property<DateTime>("dtClosing");

                    b.Property<DateTime>("dtDue");

                    b.Property<DateTime>("dtOpening");

                    b.Property<int>("idStaffAssignedTo");

                    b.Property<int>("idTicketStatus");

                    b.HasKey("idTicket");

                    b.HasIndex("idStaffAssignedTo");

                    b.HasIndex("idTicketStatus");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CRM.Entities.TicketHistory", b =>
                {
                    b.Property<int>("idTicketHistory")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dtAssigned");

                    b.Property<int>("idStaffAssigned");

                    b.Property<int>("idStaffAssigns");

                    b.Property<int>("idTicket");

                    b.Property<int>("idTicketStatus");

                    b.HasKey("idTicketHistory");

                    b.HasIndex("idStaffAssigned");

                    b.HasIndex("idStaffAssigns");

                    b.HasIndex("idTicket");

                    b.HasIndex("idTicketStatus");

                    b.ToTable("TicketHistories");
                });

            modelBuilder.Entity("CRM.Entities.TicketStatus", b =>
                {
                    b.Property<int>("idTicketStatus")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("deTicketStatus")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("idTicketStatus");

                    b.ToTable("TicketStatuses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CRM.Entities.Address", b =>
                {
                    b.HasOne("CRM.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("idCountry")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Entities.Customer", b =>
                {
                    b.HasOne("CRM.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("idAddress")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Entities.Staff", b =>
                {
                    b.HasOne("CRM.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("idAddress")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM.Entities.Store", "Store")
                        .WithMany("Staffs")
                        .HasForeignKey("idStore")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("idUser");
                });

            modelBuilder.Entity("CRM.Entities.Store", b =>
                {
                    b.HasOne("CRM.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("idAddress")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("idCountry")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Entities.Ticket", b =>
                {
                    b.HasOne("CRM.Entities.Staff", "staffAssignedTo")
                        .WithMany()
                        .HasForeignKey("idStaffAssignedTo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM.Entities.TicketStatus", "ticketStatus")
                        .WithMany()
                        .HasForeignKey("idTicketStatus")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRM.Entities.TicketHistory", b =>
                {
                    b.HasOne("CRM.Entities.Staff", "StaffAssigned")
                        .WithMany()
                        .HasForeignKey("idStaffAssigned")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM.Entities.Staff", "StaffAssigns")
                        .WithMany()
                        .HasForeignKey("idStaffAssigns")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM.Entities.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("idTicket")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRM.Entities.TicketStatus", "TicketStatus")
                        .WithMany()
                        .HasForeignKey("idTicketStatus")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
