using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.EF;
using PagedList;
using System.Data.Entity;

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
            return db.DATTOURs.Include("KHACHHANG").OrderByDescending(x => x.NgayDat).ToPagedList(page, pageSize);
        }
        
        public void Insert(DATTOUR entity)
        {
           entity.NgayDat = DateTime.Now;
            var tour = db.TOURs.Find(entity.MaTour);
            tour.SoLuong = tour.SoLuong - 1;
            var loaiphong = db.LOAIPHONGs.Find(entity.MaLP);
            entity.TongTien = (tour.GiaTour) * (entity.SoLuongNL) + (tour.GiaTour) * (entity.SoLuongTE) *(double)(tour.TiLe/100) + (loaiphong.GiaPhongDoi) * (entity.SoPhongDoi) + (loaiphong.GiaPhongDon) * (entity.SoPhongDon);
            db.DATTOURs.Add(entity);
            db.SaveChanges();
            
        }

        public void Update(DATTOUR entity)
        {
            var dattour = db.DATTOURs.Find(entity.MaTour,entity.MaKH);
            dattour.SoLuongNL = entity.SoLuongNL;
            dattour.SoLuongTE = entity.SoLuongTE;
            dattour.SoPhongDoi = entity.SoPhongDoi;
            dattour.SoPhongDon = entity.SoPhongDon;
            dattour.MaLP = entity.MaLP;
            dattour.TinhTrang = entity.TinhTrang;

            var tour = db.TOURs.Find(entity.MaTour);
            tour.SoLuong = tour.SoLuong - 1;
            var loaiphong = db.LOAIPHONGs.Find(entity.MaLP);
            dattour.TongTien = (tour.GiaTour) * (entity.SoLuongNL) + (tour.GiaTour) * (entity.SoLuongTE) * (double)(tour.TiLe / 100) + (loaiphong.GiaPhongDoi) * (entity.SoPhongDoi) + (loaiphong.GiaPhongDon) * (entity.SoPhongDon);
            db.SaveChanges();
        }

        public void Delete(DATTOUR entity)
        {
            var dattour = db.DATTOURs.Find(entity.MaTour, entity.MaKH);
            db.DATTOURs.Remove(dattour);
            db.SaveChanges();
        }

        public DATTOUR GetDatTourByMa(int matour, int makh)
        {
            return db.DATTOURs.Find(matour, makh);
        }

        public int InsertDatTour(DATTOUR entity)
        {
            entity.NgayDat = DateTime.Now;
            entity.TinhTrang = 0;
            db.DATTOURs.Add(entity);
            db.SaveChanges();
            return entity.MaTour;
        }

    }
}