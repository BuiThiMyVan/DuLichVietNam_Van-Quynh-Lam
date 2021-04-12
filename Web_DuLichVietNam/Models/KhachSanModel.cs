using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.Framework;

namespace Web_DuLichVietNam.Models
{
    public class KhachSanModel
    {
        private DuLichVNDbContext context = null;

        public KhachSanModel()
        {
            context = new DuLichVNDbContext();
        }

        public List<KHACHSAN> ListAll()
        {
            var list = context.Database.SqlQuery<KHACHSAN>("KhachSan_GetAll").ToList();
            return list;
        }
    }
}