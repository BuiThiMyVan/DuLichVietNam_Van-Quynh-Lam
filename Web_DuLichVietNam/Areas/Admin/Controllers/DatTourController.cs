using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.Models;
using PagedList;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class DatTourController : Controller
    {
        // GET: Admin/DatTour
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new DatTourModel();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        // GET: Admin/DatTour/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DatTour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DatTour/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DatTour/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DatTour/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DatTour/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DatTour/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
