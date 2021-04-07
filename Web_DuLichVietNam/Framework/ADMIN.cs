namespace Web_DuLichVietNam.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [Key]
        [StringLength(50)]
        public string TenDNAdmin { get; set; }

        [StringLength(50)]
        public string MK { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        public int? MaQuyen { get; set; }

        public virtual QUYEN QUYEN { get; set; }
    }
}
