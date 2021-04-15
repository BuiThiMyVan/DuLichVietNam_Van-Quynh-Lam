namespace Web_DuLichVietNam.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIEMDEN")]
    public partial class DIEMDEN
    {
        [Key]
        public int MaDD { get; set; }

        [StringLength(100)]
        public string TenDD { get; set; }

        public string HinhAnh { get; set; }
    }
}
