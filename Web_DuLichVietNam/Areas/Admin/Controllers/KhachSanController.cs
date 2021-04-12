using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.Models;
using Web_DuLichVietNam.Framework;
namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class KhachSanController : Controller
    {
        // GET: Admin/KhachSan
        private DuLichVNDbContext con = new DuLichVNDbContext();
        public ActionResult Index()
        {
            var model = con.KHACHSANs.ToList();
            return View(model);
        }

        // GET: Admin/KhachSan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/KhachSan/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var model = con.KHACHSANs.Find(id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = con.KHACHSANs.Find(id);
            return View(model);
        }
        // POST: Admin/KhachSan/Create
        [HttpPost]
        public ActionResult Create(KHACHSAN model)
        {
            try
            {
                con.KHACHSANs.Add(model);
                con.SaveChanges();
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/KhachSan/Edit/5
        

        // POST: Admin/KhachSan/Edit/5
        [HttpPost]
        public ActionResult Edit(KHACHSAN ks)
        {
            try
            {
                var model = con.KHACHSANs.Find(ks.MaKS);
                //sua du lieu
                model.TenKS = ks.TenKS;
                model.DiaChi = ks.DiaChi;
                model.SoPhong = ks.SoPhong;

                con.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/KhachSan/Delete/5
        

        // POST: Admin/KhachSan/Delete/5
        [HttpPost]
        public ActionResult Delete(KHACHSAN ks)
        {
            try
            {
                var model = con.KHACHSANs.Find(ks.MaKS);
                //sua du lieu
                con.KHACHSANs.Remove(model);
               
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
