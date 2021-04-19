using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Controllers
{

    public class DiemDenController : Controller
    {
        // GET: DiemDen
        private DuLichVietNamDbContext con = new DuLichVietNamDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            int id = 1;
            var model = con.TOURs.Find(id);
            return View(model);
        }

        // POST: Admin/Tour/Delete/5
        [HttpPost]
        public ActionResult Detail(TOUR tr)
        {
            try
            {
                var model = con.TOURs.Find(tr.MaTour);
                //sua du lieu
                con.TOURs.Remove(model);

                con.SaveChanges();
                return RedirectToAction("Detail");

            }
            catch
            {
                return View();
            }
        }
    }
}