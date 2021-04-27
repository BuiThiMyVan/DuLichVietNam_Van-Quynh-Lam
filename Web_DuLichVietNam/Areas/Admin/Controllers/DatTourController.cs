using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.Models;
using PagedList;
using Web_DuLichVietNam.EF;
using System.Web.UI;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class DatTourController : BaseController
    {
        // GET: Admin/DatTour
        DuLichVietNamDbContext con = new DuLichVietNamDbContext();

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new DatTourModel();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        // GET: Admin/DatTour/Details/5
        public ActionResult Details(int matour, int makh)
        {
            DATTOUR dattour = new DATTOUR();
            var model = new DatTourModel().GetDatTourByMa(matour, makh);
            ViewBag.TourDat = con.TOURs.Find(matour);
            ViewBag.LoaiPhongDat = con.LOAIPHONGs.Find(model.MaLP);
            ViewBag.KhachHangDat = con.KHACHHANGs.Find(makh);
            ViewBag.GiaTE = (ViewBag.TourDat.GiaTour) * (double)(ViewBag.TourDat.TiLe/100);

            dattour.MaTour = model.MaTour;
            dattour.MaKH = model.MaKH;
            dattour.MaLP = model.MaLP;
            dattour.SoLuongTE = model.SoLuongTE;
            dattour.SoLuongNL = model.SoLuongNL;
            dattour.SoPhongDon = model.SoPhongDon;
            dattour.SoPhongDoi = model.SoPhongDoi;
            dattour.TongTien = model.TongTien;
            dattour.NgayDat = model.NgayDat;
            dattour.YeuCau = model.YeuCau;

            return View(dattour);
        }

        // GET: Admin/DatTour/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DatTour/Create
        [HttpPost]
        public ActionResult Create(DATTOUR dattour)
        {
            try
            {
                var dao = new DatTourModel();
                dao.Insert(dattour);
                return RedirectToAction("Index");
            } catch
            {
                return View();
            }
        }

        // GET: Admin/DatTour/Edit/5
        public ActionResult Edit(int matour, int makh)
        {
            matour = Int32.Parse(Request.Params["matour"]);
            makh = Int32.Parse(Request.Params["makh"]);
            var dattour = new DatTourModel().GetDatTourByMa(matour,makh);
            return View(dattour);
        }

        // POST: Admin/DatTour/Edit/5
        [HttpPost]
        public ActionResult Edit(DATTOUR dattour)
        {
            try
            {
                var dao = new DatTourModel();
                dao.Update(dattour);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DatTour/Delete/5
        public ActionResult Delete(int matour, int makh)
        {
            matour = Int32.Parse(Request.Params["matour"]);
            makh = Int32.Parse(Request.Params["makh"]);

            var dattour = new DatTourModel().GetDatTourByMa(matour, makh);

            return View(dattour);
        }

        // POST: Admin/DatTour/Delete/5
        [HttpPost]
        public ActionResult Delete(DATTOUR dattour)
        {
            try
            {
                var dao = new DatTourModel();
                dao.Delete(dattour);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
