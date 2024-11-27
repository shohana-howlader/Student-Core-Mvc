using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MidExamMVCCore.Models;

public partial class CoreDbContext : DbContext
{
    public CoreDbContext()
    {
    }

    public CoreDbContext(DbContextOptions<CoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localDB)\\MSSQLLocalDB ; database= CoreDB; Trusted_Connection = true; TrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D71A7E74A8D16");

            entity.Property(e => e.CourseName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Modules__2B7477A71CD78BD2");

            entity.Property(e => e.ModuleName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Modules)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Modules__Student__29572725");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B9990B510E8");

            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Students__Course__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
