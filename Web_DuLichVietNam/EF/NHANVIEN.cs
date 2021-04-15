namespace Web_DuLichVietNam.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        public int MaNV { get; set; }

        [StringLength(100)]
        public string TenNV { get; set; }

        [StringLength(100)]
        public string ChucVu { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Gmail { get; set; }
    }
}
