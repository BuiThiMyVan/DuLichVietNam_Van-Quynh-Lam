using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Models
{
    public class KhachSanModel
    {
        private DuLichVietNamDbContext context = null;

        public KhachSanModel()
        {
            context = new DuLichVietNamDbContext();
        }

        public List<KHACHSAN> ListAll()
        {
            var list = context.Database.SqlQuery<KHACHSAN>("KhachSan_GetAll").ToList();
            return list;
        }
    }
}