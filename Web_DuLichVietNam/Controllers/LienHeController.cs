using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        DuLichVietNamDbContext con = new DuLichVietNamDbContext();
        public ActionResult Index()
        {
            List<CHUDE> chudelist = con.CHUDEs.ToList();
            ViewBag.ChuDeList = chudelist;
           
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(LIENHE lh)
        {
            try
            {
                con.LIENHEs.Add(lh);
                con.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                List<CHUDE> chudelist = con.CHUDEs.ToList();
                ViewBag.ChuDeList = chudelist;
                return View();
            }
           
        }
    }
}