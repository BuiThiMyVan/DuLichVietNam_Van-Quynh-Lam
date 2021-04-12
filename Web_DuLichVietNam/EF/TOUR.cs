namespace Web_DuLichVietNam.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOUR")]
    public partial class TOUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOUR()
        {
            DATTOURs = new HashSet<DATTOUR>();
        }

        [Key]
        public int MaTour { get; set; }

        [StringLength(100)]
        public string TenTour { get; set; }

        public double? GiaTour { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKhoiHanh { get; set; }

        public double? ThoiGian { get; set; }

        [StringLength(100)]
        public string DichVu { get; set; }

        [StringLength(200)]
        public string HinhAnh { get; set; }

        [StringLength(200)]
        public string HanhTrinh { get; set; }

        [StringLength(50)]
        public string NoiXuatPhat { get; set; }

        public int? MaTT { get; set; }

        public int? MaPT { get; set; }

        public int? MaHDV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATTOUR> DATTOURs { get; set; }

        public virtual HUONGDANVIEN HUONGDANVIEN { get; set; }

        public virtual PHUONGTIEN PHUONGTIEN { get; set; }

        public virtual TINHTHANH TINHTHANH { get; set; }
    }
}