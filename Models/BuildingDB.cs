using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BuildingDemo.Models
{
    public partial class BuildingDB : DbContext
    {
        public BuildingDB()
            : base("name=BuildingDB")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingType> BuildingTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ManagementBuilding> ManagementBuildings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.BuildingID)
                .IsUnicode(false);

            modelBuilder.Entity<Building>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Building>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Building>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BuildingType>()
                .HasMany(e => e.Buildings)
                .WithRequired(e => e.BuildingType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Buildings)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<ManagementBuilding>()
                .Property(e => e.BuildingID)
                .IsUnicode(false);

            modelBuilder.Entity<ManagementBuilding>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.ManagementBuilding)
                .WillCascadeOnDelete(false);
        }
    }
}
