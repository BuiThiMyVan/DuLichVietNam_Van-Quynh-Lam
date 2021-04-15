using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_DuLichVietNam.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng điền Tên Đăng Nhập")]
        public string TenDNAdmin { set; get; }

        [Required(ErrorMessage = "Vui lòng điền Mật Khẩu")]
        public string MK { set; get; }

    }
}