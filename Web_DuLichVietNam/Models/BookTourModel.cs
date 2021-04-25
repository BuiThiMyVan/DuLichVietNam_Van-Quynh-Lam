using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_DuLichVietNam.Models
{
    public class BookTourModel
    {
        [Key]
        public int MaTour { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập số lượng người lớn")]
        public int SoLuongNL { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập số lượng trẻ em")]
        public int SoLuongTE { set; get; }

        public DateTime NgayDat { set; get; }

        [Range(1, 60, ErrorMessage = "Yêu cầu chọn loại phòng")]
        public int MaLP { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập số lượng phòng đơn")]
        public int SoPhongDon { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập số lượng phòng đôi")]
        public int SoPhongDoi { set; get; }

        public string YeuCau { set; get; }

        public double? TongTien { set; get; }
    }
}