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

        [StringLength(255)]
        public string TenTour { get; set; }

        public double GiaTour { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKhoiHanh { get; set; }

        public double? ThoiGianNgay { get; set; }

        public double? ThoiGianDem { get; set; }

        public string DichVu { get; set; }

        public string HinhAnh1 { get; set; }

        public string HinhAnh2 { get; set; }

        public string HinhAnh3 { get; set; }

        public string HinhAnh4 { get; set; }

        public string HanhTrinh { get; set; }

        public string NoiXuatPhat { get; set; }

        public double TiLe { get; set; }

        public int? MaTT { get; set; }

        public int? MaPT { get; set; }

        public int? MaHDV { get; set; }

        public virtual HUONGDANVIEN HUONGDANVIEN { get; set; }

        public virtual PHUONGTIEN PHUONGTIEN { get; set; }

        public virtual TINHTHANH TINHTHANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATTOUR> DATTOURs { get; set; }
    }
}
