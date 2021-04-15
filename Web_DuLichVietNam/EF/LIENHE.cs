namespace Web_DuLichVietNam.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LIENHE")]
    public partial class LIENHE
    {
        [Key]
        public int MaLH { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public int? MaCD { get; set; }

        public string TinNhan { get; set; }

        public virtual CHUDE CHUDE { get; set; }
    }
}
