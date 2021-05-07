namespace Web_DuLichVietNam.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DATTOUR")]
    public partial class DATTOUR
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTour { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaKH { get; set; }

        public int? SoLuongNL { get; set; }

        public int? SoLuongTE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        public int? MaLP { get; set; }

        public int? SoPhongDon { get; set; }

        public int? SoPhongDoi { get; set; }

        public string YeuCau { get; set; }

        public double? TongTien { get; set; }

        public int? TinhTrang { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual LOAIPHONG LOAIPHONG { get; set; }

        public virtual TOUR TOUR { get; set; }
    }
}
