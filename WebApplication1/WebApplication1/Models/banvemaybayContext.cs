using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class banvemaybayContext : DbContext
    {
        public banvemaybayContext()
        {
        }

        public banvemaybayContext(DbContextOptions<banvemaybayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChuyenBay> ChuyenBay { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoTrinh> LoTrinh { get; set; }
        public virtual DbSet<PhieuDatVe> PhieuDatVe { get; set; }
        public virtual DbSet<VeMayBay> VeMayBay { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=banvemaybay;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuyenBay>(entity =>
            {
                entity.Property(e => e.ChuyenBayId)
                    .HasColumnName("ChuyenBayID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LoaiMayBay)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NgayCatCanh).HasColumnType("date");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.Property(e => e.KhachHangId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cmnd)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TenKhachHang)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LoTrinh>(entity =>
            {
                entity.Property(e => e.LoTrinhId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SanBayDen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SanBayDi)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PhieuDatVe>(entity =>
            {
                entity.Property(e => e.PhieuDatVeId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChuyenBayId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.KhachHangId)
                    .IsRequired()
                    .HasColumnName("KhachHangID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LoTrinhId)
                    .IsRequired()
                    .HasColumnName("LoTrinhID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgayDat).HasColumnType("date");

                entity.HasOne(d => d.ChuyenBay)
                    .WithMany(p => p.PhieuDatVe)
                    .HasForeignKey(d => d.ChuyenBayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuDatVe_ChuyenBay");

                entity.HasOne(d => d.KhachHang)
                    .WithMany(p => p.PhieuDatVe)
                    .HasForeignKey(d => d.KhachHangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuDatVe_KhachHang1");

                entity.HasOne(d => d.LoTrinh)
                    .WithMany(p => p.PhieuDatVe)
                    .HasForeignKey(d => d.LoTrinhId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuDatVe_LoTrinh");
            });

            modelBuilder.Entity<VeMayBay>(entity =>
            {
                entity.Property(e => e.VeMayBayId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChuyenBayId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.KhoangGhe)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PhieuDatVeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SoGhe)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.ChuyenBay)
                    .WithMany(p => p.VeMayBay)
                    .HasForeignKey(d => d.ChuyenBayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VeMayBay_ChuyenBay");

                entity.HasOne(d => d.PhieuDatVe)
                    .WithMany(p => p.VeMayBay)
                    .HasForeignKey(d => d.PhieuDatVeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VeMayBay_PhieuDatVe1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
