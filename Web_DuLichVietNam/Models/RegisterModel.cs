using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_DuLichVietNam.Models
{
    public class RegisterModel
    {
        [Key]
        public int MaKH { get; set; }

        [Required(ErrorMessage ="Yêu cầu nhập họ tên")]
        [Display(Name = "Họ Tên")]
        public string TenKH { set; get; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Yêu cầu nhập ngày sinh")]
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { set; get; }

        [Display(Name = "Giới Tính")]
        public int GioiTinh { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        [Display(Name = "Số Điện Thoại")]
        public string SDT { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập email")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        [Display(Name = "Tên Đăng Nhập")]
        public string TenDN { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        [Display(Name = "Mật Khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        public string MK { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập xác nhận mật khẩu")]
        [Display(Name = "Xác Nhận Mật Khẩu")]
        [Compare("MK", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string XacNhanMK { set; get; }
    }
}