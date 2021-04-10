using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.EF;
using PagedList;

namespace Web_DuLichVietNam.Models
{
    public class DatTourModel
    {
        DuLichVietNamDbContext db = null;
        public DatTourModel()
        {
            db = new DuLichVietNamDbContext();
        }

        public IEnumerable<DATTOUR> ListAllPaging(int page, int pageSize)
        {
            return db.DATTOURs.OrderByDescending(x => x.NgayDat).ToPagedList(page, pageSize);
        }
        
        public bool Update(DATTOUR entity)
        {
            try
            {
                var dattour = db.DATTOURs.Find(entity.MaKH);
                dattour.SoLuongNL = entity.SoLuongNL;
                dattour.SoLuongTE = entity.SoLuongTE;
                dattour.SoPhongDoi = entity.SoPhongDoi;
                dattour.SoPhongDon = entity.SoPhongDon;
                dattour.MaLP = entity.MaLP;
                db.SaveChanges();
                return true;
            } catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}