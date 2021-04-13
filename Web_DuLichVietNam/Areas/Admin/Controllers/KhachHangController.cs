using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        private DuLichVietNamDbContext con = new DuLichVietNamDbContext();
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            var model = con.KHACHHANGs.ToList();
            return View(model);
        }

        // GET: Admin/KhachHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhachHang/Create
        [HttpPost]
        public ActionResult Create(KHACHHANG model)
        {
            try
            {
                model.MaQuyen = 2;
                con.KHACHHANGs.Add(model);
                con.SaveChanges();
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/KhachHang/Edit/5
        public ActionResult Edit(int id)
        {
            var model = con.KHACHHANGs.Find(id);
            return View(model);
        }

        // POST: Admin/KhachHang/Edit/5
        [HttpPost]
        public ActionResult Edit(KHACHHANG kh)
        {
            try
            {
                var model = con.KHACHHANGs.Find(kh.MaKH);
                //sua du lieu
                model.TenKH = kh.TenKH;
                model.NgaySinh = kh.NgaySinh;
                model.GioiTinh = kh.GioiTinh;
                model.SDT = kh.SDT;
                model.TenDN = kh.TenDN;
                model.MK = kh.MK;
                model.Email = kh.Email;
                con.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            var model = con.KHACHHANGs.Find(id);
            return View(model);
        }

        // POST: Admin/KhachHang/Delete/5
        [HttpPost]
        public ActionResult Delete(KHACHHANG kh)
        {
            try
            {
                var model = con.KHACHHANGs.Find(kh.MaKH);
                //sua du lieu
                con.KHACHHANGs.Remove(model);

                con.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
