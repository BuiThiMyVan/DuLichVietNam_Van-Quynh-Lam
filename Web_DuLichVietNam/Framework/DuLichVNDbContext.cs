namespace Web_DuLichVietNam.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DuLichVNDbContext : DbContext
    {
        public DuLichVNDbContext()
            : base("name=DuLichVNDbContext")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<DATTOUR> DATTOURs { get; set; }
        public virtual DbSet<HUONGDANVIEN> HUONGDANVIENs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<KHACHSAN> KHACHSANs { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONGs { get; set; }
        public virtual DbSet<PHUONGTIEN> PHUONGTIENs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TINHTHANH> TINHTHANHs { get; set; }
        public virtual DbSet<TOUR> TOURs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MK)
                .IsUnicode(false);

            modelBuilder.Entity<DATTOUR>()
                .Property(e => e.MaTour)
                .IsUnicode(false);

            modelBuilder.Entity<DATTOUR>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<DATTOUR>()
                .Property(e => e.MaLP)
                .IsUnicode(false);

            modelBuilder.Entity<DATTOUR>()
                .Property(e => e.MaHDV)
                .IsUnicode(false);

            modelBuilder.Entity<HUONGDANVIEN>()
                .Property(e => e.MaHDV)
                .IsUnicode(false);

            modelBuilder.Entity<HUONGDANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MK)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DATTOURs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHSAN>()
                .Property(e => e.MaKS)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.MaLP)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.MaKS)
                .IsUnicode(false);

            modelBuilder.Entity<PHUONGTIEN>()
                .Property(e => e.MaPT)
                .IsUnicode(false);

            modelBuilder.Entity<PHUONGTIEN>()
                .Property(e => e.BienKS)
                .IsUnicode(false);

            modelBuilder.Entity<TINHTHANH>()
                .Property(e => e.MaTT)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MaTour)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MaTT)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MaPT)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .HasMany(e => e.DATTOURs)
                .WithRequired(e => e.TOUR)
                .WillCascadeOnDelete(false);
        }
    }
}
