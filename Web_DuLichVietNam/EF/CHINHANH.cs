namespace Web_DuLichVietNam.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHINHANH")]
    public partial class CHINHANH
    {
        [Key]
        public int MaCN { get; set; }

        [StringLength(100)]
        public string TenCN { get; set; }

        public string DiaChi { get; set; }

        public string Email { get; set; }

        [StringLength(12)]
        public string DienThoai { get; set; }
    }
}
