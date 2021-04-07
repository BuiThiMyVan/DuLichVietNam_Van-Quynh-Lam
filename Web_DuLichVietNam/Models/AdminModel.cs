using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.Framework;

namespace Web_DuLichVietNam.Models
{
    public class AdminModel
    {
        private DuLichVNDbContext context = null;
        
        public AdminModel()
        {
            context = new DuLichVNDbContext();
        }

        public bool Login(string tendangnhap, string matkhau)
        {
            object[] sqlParams =
            {
                new SqlParameter("@tendangnhap", tendangnhap),
                new SqlParameter("@matkhau", matkhau),
            };
            var res = context.Database.SqlQuery<bool>("KIEMTRAADMIN @tendangnhap, @matkhau", sqlParams).SingleOrDefault();

            return res;
        }
    }
}