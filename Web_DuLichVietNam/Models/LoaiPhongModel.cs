using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Models
{
    public class LoaiPhongModel
    {
        DuLichVietNamDbContext db = new DuLichVietNamDbContext();

        public LOAIPHONG GetLoaiPhong(int MaLP)
        {
            return db.LOAIPHONGs.SingleOrDefault(x => x.MaLP == MaLP);
        }
    }
}