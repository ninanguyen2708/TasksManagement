using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryList> CategoryLists { get; set; }

    public virtual DbSet<DepartmentList> DepartmentLists { get; set; }

    public virtual DbSet<EmployeeList> EmployeeLists { get; set; }

    public virtual DbSet<TaskList> TaskLists { get; set; }

    public virtual DbSet<TrainingCourse> TrainingCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=todo.db;User Id=admin;Password=admin123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryList>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("CategoryList");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<DepartmentList>(entity =>
        {
            entity.HasKey(e => e.DepartmentId);

            entity.ToTable("DepartmentList");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
        });

        modelBuilder.Entity<EmployeeList>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("EmployeeList");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeeLists)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_EmployeeList_DepartmentList");
        });

        modelBuilder.Entity<TaskList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TaskList_1");

            entity.ToTable("TaskList");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())", "DF_TaskList_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.Category).WithMany(p => p.TaskLists)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_TaskList_CategoryList");

            entity.HasOne(d => d.Employee).WithMany(p => p.TaskLists)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_TaskList_EmployeeList");
        });

        modelBuilder.Entity<TrainingCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TrainingCourse_1");

            entity.ToTable("TrainingCourse");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Department).WithMany(p => p.TrainingCourses)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_TrainingCourse_DepartmentList");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
