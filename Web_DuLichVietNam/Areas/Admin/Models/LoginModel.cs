using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_DuLichVietNam.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string TenDNAdmin { set; get; }

        public string MK { set; get; }

    }
}