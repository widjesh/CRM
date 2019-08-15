using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Entities
{
    public class CRMContext : IdentityDbContext
    {
       public CRMContext(DbContextOptions<CRMContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketHistory> TicketHistories { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Staff>().HasIndex(k => k.adEmail).IsUnique(); // Condition : one unique email adderss
            modelBuilder.Entity<Customer>().HasIndex(k => k.adEmail).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(k => k.nuCustomer).IsUnique();
            //var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            //                                .SelectMany(t => t.GetForeignKeys())
            //                                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            //foreach (var fk in cascadeFKs)
            //    fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
