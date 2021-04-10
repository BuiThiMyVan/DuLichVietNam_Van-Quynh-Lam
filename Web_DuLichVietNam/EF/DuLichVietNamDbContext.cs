namespace Web_DuLichVietNam.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DuLichVietNamDbContext : DbContext
    {
        public DuLichVietNamDbContext()
            : base("name=DuLichVietNamDbContext")
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
        public virtual DbSet<TINHTHANH> TINHTHANHs { get; set; }
        public virtual DbSet<TOUR> TOURs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MK)
                .IsUnicode(false);

            modelBuilder.Entity<HUONGDANVIEN>()
                .Property(e => e.SDT)
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

            modelBuilder.Entity<PHUONGTIEN>()
                .Property(e => e.BienKS)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .HasMany(e => e.DATTOURs)
                .WithRequired(e => e.TOUR)
                .WillCascadeOnDelete(false);
        }
    }
}
