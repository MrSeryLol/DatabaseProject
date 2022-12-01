using System;
using System.Collections.Generic;
using DbManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbManager;

public partial class OfficeEquipmentContext : DbContext
{
    public OfficeEquipmentContext()
    {
    }

    public OfficeEquipmentContext(DbContextOptions<OfficeEquipmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Hardware> Hardwares { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=OfficeEquipment;Username=postgres;Password=1234GvOzd123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("pk_categoryid");

            entity.ToTable("category");

            entity.HasIndex(e => e.CategoryName, "category_category_name_key").IsUnique();

            entity.Property(e => e.CategoryId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("category_id");
            entity.Property(e => e.CategoryName).HasColumnName("category_name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("pk_employeeid");

            entity.ToTable("employee");

            entity.HasIndex(e => e.WorkplaceId, "employee_workplace_id_key").IsUnique();

            entity.Property(e => e.EmployeeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("employee_id");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.SecondName).HasColumnName("second_name");
            entity.Property(e => e.WorkplaceId).HasColumnName("workplace_id");

            entity.HasMany(d => d.Categories).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_categoryid"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_emolyeeid"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "CategoryId").HasName("pk_employee_category");
                        j.ToTable("employee_category");
                    });
        });

        modelBuilder.Entity<Hardware>(entity =>
        {
            entity.HasKey(e => e.HardwareId).HasName("pk_hardwareid");

            entity.ToTable("hardware");

            entity.Property(e => e.HardwareId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("hardware_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.HardwareName).HasColumnName("hardware_name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ProductionYear).HasColumnName("production_year");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");

            entity.HasOne(d => d.Category).WithMany(p => p.Hardwares)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_categoryid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
