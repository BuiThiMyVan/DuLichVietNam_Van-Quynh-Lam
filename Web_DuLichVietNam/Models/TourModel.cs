using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_DuLichVietNam.Models
{
    public class TourModel
    {
        [Key]
        public int MaTour { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập tên tour")]
        public string TenTour { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập giá tour")]
        public double GiaTour { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập số lượng")]
        public int SoLuong { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập ngày khởi hành")]
        public DateTime NgayKhoiHanh { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập số ngày")]
        public int ThoiGianNgay { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập số đêm")]
        public int ThoiGianDem { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập dịch vụ")]
        [AllowHtml]
        public string DichVu { set; get; }

        public string HinhAnh1 { set; get; }

        public string HinhAnh2 { set; get; }

        public string HinhAnh3 { set; get; }

        public string HinhAnh4 { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập hành trình")]
        [AllowHtml]
        public string HanhTrinh { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập nơi xuất phát")]
        public string NoiXuatPhat { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập tỉ lệ")]
        [Range(0, 100, ErrorMessage = "Yêu cầu nhập đúng tỉ lệ")]
        public double TiLe { set; get; }

        public int MaTT { set; get; }

        public int MaPT { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập mã hướng dẫn viên")]
        public int MaHDV { set; get; }
    }
}