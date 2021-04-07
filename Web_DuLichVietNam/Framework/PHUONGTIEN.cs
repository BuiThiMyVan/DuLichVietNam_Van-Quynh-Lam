namespace Web_DuLichVietNam.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHUONGTIEN")]
    public partial class PHUONGTIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHUONGTIEN()
        {
            TOURs = new HashSet<TOUR>();
        }

        [Key]
        [StringLength(50)]
        public string MaPT { get; set; }

        [StringLength(50)]
        public string TenPT { get; set; }

        public int? SoCho { get; set; }

        [StringLength(50)]
        public string BienKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOUR> TOURs { get; set; }
    }
}
