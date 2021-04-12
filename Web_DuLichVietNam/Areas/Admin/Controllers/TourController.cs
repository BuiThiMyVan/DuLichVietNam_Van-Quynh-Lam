using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.Models;
using Web_DuLichVietNam.Framework;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class TourController : Controller
    {
        // GET: Admin/Tour
        private DuLichVNDbContext con = new DuLichVNDbContext();
        public ActionResult Index()
        {
            var model = con.TOURs.ToList();
            return View(model);
        }

        // GET: Admin/Tour/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Tour/Create
        public ActionResult Create()
        {
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
                return View();
            }
        }

        // GET: Admin/Tour/Edit/5
        public ActionResult Edit(int id)
        {
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
                model.HinhAnh = tr.HinhAnh;


                con.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Tour/Delete/5
        public ActionResult Delete(int id)
        {
            var model = con.TOURs.Find(id);
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
                return View();
            }
        }
    }
}
