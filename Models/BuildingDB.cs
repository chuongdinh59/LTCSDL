using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BuildingDemo.Models
{
    public partial class BuildingDB : DbContext
    {
        public BuildingDB()
            : base("name=BuildingDB3")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingType> BuildingTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ManagementBuilding> ManagementBuildings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Building>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Building>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<BuildingType>()
                .HasMany(e => e.Buildings)
                .WithRequired(e => e.BuildingType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Schedules)
                .WithOptional(e => e.Customer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Schedules)
                .WithOptional(e => e.Employee)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Image>()
                .Property(e => e.BuildingID)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<ManagementBuilding>()
                .Property(e => e.BuildingID)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.BuildingID)
                .IsUnicode(false);
        }
    }
}
