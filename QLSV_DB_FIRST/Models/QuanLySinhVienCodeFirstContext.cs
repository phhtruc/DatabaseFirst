using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLSV_DB_FIRST.Models;

public partial class QuanLySinhVienCodeFirstContext : DbContext
{
    public QuanLySinhVienCodeFirstContext()
    {
    }

    public QuanLySinhVienCodeFirstContext(DbContextOptions<QuanLySinhVienCodeFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-IPDB6V8;Initial Catalog=QuanLySinhVienCodeFirst;Persist Security Info=True;User ID=sa;Password=12345;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TenKhoa).HasColumnName("tenKhoa");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasIndex(e => e.KhoaId, "IX_Lops_khoaId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KhoaId).HasColumnName("khoaId");
            entity.Property(e => e.TenLop).HasColumnName("tenLop");

            entity.HasOne(d => d.Khoa).WithMany(p => p.Lops).HasForeignKey(d => d.KhoaId);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasIndex(e => e.LopId, "IX_SinhViens_lopId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.LopId).HasColumnName("lopId");
            entity.Property(e => e.TenSinhVien).HasColumnName("tenSinhVien");

            entity.HasOne(d => d.Lop).WithMany(p => p.SinhViens).HasForeignKey(d => d.LopId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
