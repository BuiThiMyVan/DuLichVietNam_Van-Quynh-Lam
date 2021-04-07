namespace Web_DuLichVietNam.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHSAN")]
    public partial class KHACHSAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHSAN()
        {
            LOAIPHONGs = new HashSet<LOAIPHONG>();
        }

        [Key]
        [StringLength(50)]
        public string MaKS { get; set; }

        [StringLength(50)]
        public string TenKS { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        public int? SoPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOAIPHONG> LOAIPHONGs { get; set; }
    }
}
