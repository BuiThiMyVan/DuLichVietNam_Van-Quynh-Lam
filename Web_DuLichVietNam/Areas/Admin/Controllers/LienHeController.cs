using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.EF;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class LienHeController : BaseController
    {
        DuLichVietNamDbContext db = new DuLichVietNamDbContext();
        // GET: Admin/LienHe
        public ActionResult Index()
        {
            ViewBag.ChuDe = db.CHUDEs.ToList();
            var model = db.LIENHEs.ToList();
            return View(model);
        }
    }
}