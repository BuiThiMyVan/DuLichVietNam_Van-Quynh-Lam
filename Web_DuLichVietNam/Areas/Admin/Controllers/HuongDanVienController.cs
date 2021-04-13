using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class HuongDanVienController : Controller
    {
        private DuLichVietNamDbContext con = new DuLichVietNamDbContext();
        // GET: Admin/HuongDanVien
        public ActionResult Index()
        {
            var model = con.HUONGDANVIENs.ToList();
            return View(model);
        }

        // GET: Admin/HuongDanVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/HuongDanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HuongDanVien/Create
        [HttpPost]
        public ActionResult Create(HUONGDANVIEN model)
        {
            try
            {
                con.HUONGDANVIENs.Add(model);
                con.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/HuongDanVien/Edit/5
        public ActionResult Edit(int id)
        {
            var model = con.HUONGDANVIENs.Find(id);
            return View(model);
        }

        // POST: Admin/HuongDanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(HUONGDANVIEN hdv)
        {
            try
            {
                var model = con.HUONGDANVIENs.Find(hdv.MaHDV);
                //sua du lieu
                model.TenHDV = hdv.TenHDV;
                model.SDT = hdv.SDT;
                model.DiaChi = hdv.DiaChi;
                con.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/HuongDanVien/Delete/5
        public ActionResult Delete(int id)
        {
            var model = con.HUONGDANVIENs.Find(id);
            return View(model);
        }

        // POST: Admin/HuongDanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(HUONGDANVIEN hdv)
        {
            try
            {
                var model = con.HUONGDANVIENs.Find(hdv.MaHDV);
                //sua du lieu
                con.HUONGDANVIENs.Remove(model);

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
