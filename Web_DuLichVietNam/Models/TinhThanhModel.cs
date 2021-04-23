using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Models
{
    public class TinhThanhModel
    {
        private DuLichVietNamDbContext db = null;

        public TinhThanhModel()
        {
            db = new DuLichVietNamDbContext();
        }

        public List<TINHTHANH> ListAll()
        {
            return db.TINHTHANHs.ToList();
        }
    }
}