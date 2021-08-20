using DemoApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.DBContexts
{
    public class MyDBContext : DbContext
    {
        public DbSet<PartyIdentity> PartyIdentity { get; set; }
        public DbSet<PartyContact> PartyContact { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<PartyIdentity>().ToTable("PartyIdentities");
            modelBuilder.Entity<PartyContact>().ToTable("PartyContacts");

            // Configure Primary Keys  
            modelBuilder.Entity<PartyIdentity>().HasKey(pi => pi.Id).HasName("PK_PartyIdentities");
            modelBuilder.Entity<PartyContact>().HasKey(pc => pc.Id).HasName("PK_PartyContacts");

            // Configure indexes  
            

            // Configure columns  
            modelBuilder.Entity<PartyIdentity>().Property(pi => pi.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<PartyIdentity>().Property(pi => pi.FirstName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PartyIdentity>().Property(pi => pi.LastName).HasColumnType("nvarchar(100)").IsRequired();

            modelBuilder.Entity<PartyContact>().Property(pc => pc.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<PartyContact>().Property(pc => pc.Address).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PartyContact>().Property(pc => pc.PartyIdentityId).HasColumnType("int").IsRequired();

            // Configure relationships  
            modelBuilder.Entity<PartyContact>().HasOne<PartyIdentity>().WithMany().
                HasPrincipalKey(pi => pi.Id).HasForeignKey(pc => pc.PartyIdentityId).
                OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_PartyContacts_PartyIdentities");
        }
    }
}
