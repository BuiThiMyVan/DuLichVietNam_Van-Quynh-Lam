using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.Models;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class TourController : Controller
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
        public ActionResult Create(TOUR model)
        {
            try
            {
                con.TOURs.Add(model);
                con.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                List<TINHTHANH> tinhthanhlist = con.TINHTHANHs.ToList();
                ViewBag.TinhThanhList = tinhthanhlist;
                List<PHUONGTIEN> phuongtienlist = con.PHUONGTIENs.ToList();
                ViewBag.PhuongTienList = phuongtienlist;
                return View();
            }
        }

        // GET: Admin/Tour/Edit/5
        public ActionResult Edit(int id)
        {
            List<TINHTHANH> tinhthanhlist = con.TINHTHANHs.ToList();
            ViewBag.TinhThanhList = tinhthanhlist;
            List<PHUONGTIEN> phuongtienlist = con.PHUONGTIENs.ToList();
            ViewBag.PhuongTienList = phuongtienlist;

            var model = con.TOURs.Find(id);
            return View(model);
        }

        // POST: Admin/Tour/Edit/5
        [HttpPost]
        public ActionResult Edit(TOUR tr)
        {
            try
            {
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
                model.MaHDV = tr.MaHDV;
                model.MaPT = tr.MaPT;
                model.MaTT = tr.MaTT;
                con.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                List<TINHTHANH> tinhthanhlist = con.TINHTHANHs.ToList();
                ViewBag.TinhThanhList = tinhthanhlist;
                List<PHUONGTIEN> phuongtienlist = con.PHUONGTIENs.ToList();
                ViewBag.PhuongTienList = phuongtienlist;
                return View();
            }
        }

        // GET: Admin/Tour/Delete/5
        public ActionResult Delete(int id)
        {
            var model = con.TOURs.Find(id);
            ViewBag.TenTinhThanh = con.TINHTHANHs.Find(model.MaTT);
            ViewBag.TenPhuongTien = con.PHUONGTIENs.Find(model.MaPT);
            return View(model);
        }

        // POST: Admin/Tour/Delete/5
        [HttpPost]
        public ActionResult Delete(TOUR tr)
        {
            try
            {
                var model = con.TOURs.Find(tr.MaTour);
                //sua du lieu
                con.TOURs.Remove(model);

                con.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                List<TINHTHANH> tinhthanhlist = con.TINHTHANHs.ToList();
                ViewBag.TinhThanhList = tinhthanhlist;
                List<PHUONGTIEN> phuongtienlist = con.PHUONGTIENs.ToList();
                ViewBag.PhuongTienList = phuongtienlist;
                return View();
            }
        }
    }
}
