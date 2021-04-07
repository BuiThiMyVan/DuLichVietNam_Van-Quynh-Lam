namespace Web_DuLichVietNam.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIPHONG")]
    public partial class LOAIPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIPHONG()
        {
            DATTOURs = new HashSet<DATTOUR>();
        }

        [Key]
        [StringLength(50)]
        public string MaLP { get; set; }

        [StringLength(50)]
        public string TenLoai { get; set; }

        public double? GiaPhongDon { get; set; }

        public double? GiaPhongDoi { get; set; }

        [StringLength(50)]
        public string MaKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATTOUR> DATTOURs { get; set; }

        public virtual KHACHSAN KHACHSAN { get; set; }
    }
}
