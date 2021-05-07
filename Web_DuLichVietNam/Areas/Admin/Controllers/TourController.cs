using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.Models;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class TourController : BaseController
    {
        // GET: Admin/Tour
        private DuLichVietNamDbContext con = new DuLichVietNamDbContext();
        public ActionResult Index()
        {
            var model = con.TOURs.ToList();
            return View(model);
        }

        // GET: Admin/Tour/Details/5
        public ActionResult Details(int id)
        {
            var model = con.TOURs.Find(id);
            ViewBag.TenTinhThanh = con.TINHTHANHs.Find(model.MaTT);
            ViewBag.TenPhuongTien = con.PHUONGTIENs.Find(model.MaPT);
            return View(model);
        }


        // GET: Admin/Tour/Create
        public ActionResult Create()
        {
            List<TINHTHANH> tinhthanhlist = con.TINHTHANHs.ToList();
            ViewBag.TinhThanhList = tinhthanhlist;
            List<PHUONGTIEN> phuongtienlist = con.PHUONGTIENs.ToList();
            ViewBag.PhuongTienList = phuongtienlist;
            return View();
        }

        // POST: Admin/Tour/Create
        [HttpPost]
        public ActionResult Create(TourModel tr)
        {
            List<TINHTHANH> tinhthanhlist = con.TINHTHANHs.ToList();
            ViewBag.TinhThanhList = tinhthanhlist;
            List<PHUONGTIEN> phuongtienlist = con.PHUONGTIENs.ToList();
            ViewBag.PhuongTienList = phuongtienlist;
            if (ModelState.IsValid)
            {
                TOUR model = new TOUR();
                model.TenTour = tr.TenTour;
                model.GiaTour = tr.GiaTour;
                model.SoLuong = tr.SoLuong;
                model.HinhAnh1 = tr.HinhAnh1;
                model.HinhAnh2 = tr.HinhAnh2;
                model.HinhAnh3 = tr.HinhAnh3;
                model.HinhAnh4 = tr.HinhAnh4;
                model.DichVu = tr.DichVu;
                model.HanhTrinh = tr.HanhTrinh;
                model.NgayKhoiHanh = tr.NgayKhoiHanh;
                model.NoiXuatPhat = tr.NoiXuatPhat;
                model.ThoiGianDem = tr.ThoiGianDem;
                model.ThoiGianNgay = tr.ThoiGianNgay;
                model.TiLe = tr.TiLe;
                model.MaHDV = tr.MaHDV;
                model.MaPT = tr.MaPT;
                model.MaTT = tr.MaTT;

                con.TOURs.Add(model);
                con.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(tr);
        }

        // GET: Admin/Tour/Edit/5
        public ActionResult Edit(int id)
        {
            List<TINHTHANH> tinhthanhlist = con.TINHTHANHs.ToList();
            ViewBag.TinhThanhList = tinhthanhlist;
            List<PHUONGTIEN> phuongtienlist = con.PHUONGTIENs.ToList();
            ViewBag.PhuongTienList = phuongtienlist;

            var tr = con.TOURs.Find(id);
            TourModel model = new TourModel();
            model.MaTour = tr.MaTour;
            model.TenTour = tr.TenTour;
            model.GiaTour = tr.GiaTour;
            model.SoLuong = (int)tr.SoLuong;
            model.HinhAnh1 = tr.HinhAnh1;
            model.HinhAnh2 = tr.HinhAnh2;
            model.HinhAnh3 = tr.HinhAnh3;
            model.HinhAnh4 = tr.HinhAnh4;
            model.DichVu = tr.DichVu;
            model.HanhTrinh = tr.HanhTrinh;
            model.NgayKhoiHanh = (DateTime)tr.NgayKhoiHanh;
            model.NoiXuatPhat = tr.NoiXuatPhat;
            model.ThoiGianDem = (int)tr.ThoiGianDem;
            model.ThoiGianNgay = (int)tr.ThoiGianNgay;
            model.TiLe = tr.TiLe;
            model.MaHDV = (int)tr.MaHDV;
            model.MaPT = (int)tr.MaPT;
            model.MaTT = (int)tr.MaTT;

            return View(model);
        }

        // POST: Admin/Tour/Edit/5
        [HttpPost]
        public ActionResult Edit(TourModel tr)
        {
            if (ModelState.IsValid)
            {
                List<TINHTHANH> tinhthanhlist = con.TINHTHANHs.ToList();
                ViewBag.TinhThanhList = tinhthanhlist;
                List<PHUONGTIEN> phuongtienlist = con.PHUONGTIENs.ToList();
                ViewBag.PhuongTienList = phuongtienlist;

                var model = con.TOURs.Find(tr.MaTour);
                //sua du lieu
                model.TenTour = tr.TenTour;
                model.GiaTour = tr.GiaTour;
                model.SoLuong = tr.SoLuong;
                model.HinhAnh1 = tr.HinhAnh1;
                model.HinhAnh2 = tr.HinhAnh2;
                model.HinhAnh3 = tr.HinhAnh3;
                model.HinhAnh4 = tr.HinhAnh4;
                model.DichVu = tr.DichVu;
                model.HanhTrinh = tr.HanhTrinh;
                model.NgayKhoiHanh = tr.NgayKhoiHanh;
                model.NoiXuatPhat = tr.NoiXuatPhat;
                model.ThoiGianDem = tr.ThoiGianDem;
                model.ThoiGianNgay = tr.ThoiGianNgay;
                model.TiLe = tr.TiLe;
                model.MaHDV = tr.MaHDV;
                model.MaPT = tr.MaPT;
                model.MaTT = tr.MaTT;
                con.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<TINHTHANH> tinhthanhlist = con.TINHTHANHs.ToList();
                ViewBag.TinhThanhList = tinhthanhlist;
                List<PHUONGTIEN> phuongtienlist = con.PHUONGTIENs.ToList();
                ViewBag.PhuongTienList = phuongtienlist;
                return View(tr);
            }
        }

        // GET: Admin/Tour/Delete/5
        public ActionResult Delete(int id)
        {
            var tr = con.TOURs.Find(id);
            ViewBag.TenTinhThanh = con.TINHTHANHs.Find(tr.MaTT);
            ViewBag.TenPhuongTien = con.PHUONGTIENs.Find(tr.MaPT);
            TourModel model = new TourModel();
            model.MaTour = tr.MaTour;
            model.TenTour = tr.TenTour;
            model.GiaTour = tr.GiaTour;
            model.SoLuong = (int)tr.SoLuong;
            model.HinhAnh1 = tr.HinhAnh1;
            model.HinhAnh2 = tr.HinhAnh2;
            model.HinhAnh3 = tr.HinhAnh3;
            model.HinhAnh4 = tr.HinhAnh4;
            model.DichVu = tr.DichVu;
            model.HanhTrinh = tr.HanhTrinh;
            model.NgayKhoiHanh = (DateTime)tr.NgayKhoiHanh;
            model.NoiXuatPhat = tr.NoiXuatPhat;
            model.ThoiGianDem = (int)tr.ThoiGianDem;
            model.ThoiGianNgay = (int)tr.ThoiGianNgay;
            model.TiLe = tr.TiLe;
            model.MaHDV = (int)tr.MaHDV;
            model.MaPT = (int)tr.MaPT;
            model.MaTT = (int)tr.MaTT;
            return View(model);
        }

        // POST: Admin/Tour/Delete/5
        [HttpPost]
        public ActionResult Delete(TourModel tr)
        {
            try
            {
                var model = con.TOURs.Find(tr.MaTour);
                ViewBag.TenTinhThanh = con.TINHTHANHs.Find(tr.MaTT);
                ViewBag.TenPhuongTien = con.PHUONGTIENs.Find(tr.MaPT);
                //sua du lieu
                con.TOURs.Remove(model);
                con.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                ViewBag.TenTinhThanh = con.TINHTHANHs.Find(tr.MaTT);
                ViewBag.TenPhuongTien = con.PHUONGTIENs.Find(tr.MaPT);
                return View(tr);
            }
        }
    }
}
