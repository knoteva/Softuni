using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    class SalesContext : DbContext
    {
        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);

                entity.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

                entity.Property(p => p.Quantity)
                .IsRequired();

                entity.Property(p => p.Price)
                .IsRequired();

                entity.Property(p => p.Description)
               .HasMaxLength(250)
               .IsRequired(false)
               .IsUnicode()
               .HasDefaultValue("No description");

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);

                entity.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();

                entity.Property(c => c.Email)
                .HasMaxLength(80)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(c => c.CreditCardNumber)
                .HasMaxLength(20)
                .IsRequired()
                .IsUnicode(false);

                //entity
                //.HasMany(c => c.Sales)
                //.WithOne(s => s.Customer)
                //.HasForeignKey(s => s.CustomerId);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(st => st.StoreId);

                entity.Property(st => st.Name)
                .HasMaxLength(80)
                .IsRequired()
                .IsUnicode();

                //entity
                //.HasMany(st => st.Sales)
                //.WithOne(s => s.Store)
                //.HasForeignKey(s => s.StoreId);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.SaleId);

                entity.Property(s => s.Date)
                .IsRequired()
                .HasColumnType("DATETIME2")
                .IsUnicode(false)
                .HasDefaultValueSql("GETDATE()");

                entity
                .HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId);

                entity
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

                entity
                .HasOne(s => s.Store)
                .WithMany(st => st.Sales)
                .HasForeignKey(s => s.StoreId);
            });
        }
    }
}
