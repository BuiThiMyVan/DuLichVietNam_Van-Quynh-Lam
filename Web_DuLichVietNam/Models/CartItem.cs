using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Models
{
    [Serializable]
    public class CartItem
    {
        public TOUR Tour { set; get; }
    }
}