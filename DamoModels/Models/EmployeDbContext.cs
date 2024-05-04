using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DamoModels.Models
{
    public partial class EmployeDbContext : DbContext
    {
        public EmployeDbContext()
        {
        }

        public EmployeDbContext(DbContextOptions<EmployeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeInfo> EmployeInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=JOY\\MSSQLSERVER01;Database=EmployeDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeInfo>(entity =>
            {
                entity.HasKey(e => e.Id); // Define Id as the primary key

                entity.ToTable("EmployeInfo");

                entity.Property(e => e.Company)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Configure Id as auto-generated

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.YearoffExprience)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
