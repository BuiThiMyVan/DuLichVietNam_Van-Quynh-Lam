using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.EF;
using Web_DuLichVietNam.Models;

namespace Web_DuLichVietNam.Controllers
{
    public class ChinhSuaThongTinController : Controller
    {
        // GET: ChinhSuaThongTin
        DuLichVietNamDbContext con = new DuLichVietNamDbContext();

        public ActionResult Index()
        {

            var session = (DangNhapModel)Session[Web_DuLichVietNam.Common.CommonConstants.USER_SESSION];
            ViewBag.KhachHang = new KhachHangModel().GetByUsername(session.TenDN);
            if (ModelState.IsValid)
            {
                var model = con.KHACHHANGs.Find(session.MaKH);

                return View(model);
            }
            return View();

        }
        [HttpPost]
        public ActionResult Index(KHACHHANG kh)
        {

            var dao = new KhachHangModel();
            var session = (DangNhapModel)Session[Web_DuLichVietNam.Common.CommonConstants.USER_SESSION];
            ViewBag.KhachHang = new KhachHangModel().GetByUsername(session.TenDN);

            if (ModelState.IsValid)
            {
                try
                {
                    var model = con.KHACHHANGs.Find(kh.MaKH);
                    //sua du lieu
                    model.TenKH = kh.TenKH;
                    model.NgaySinh = kh.NgaySinh;
                    model.GioiTinh = kh.GioiTinh;
                    model.SDT = kh.SDT;
                    model.Email = kh.Email;
                    model.TenDN = kh.TenDN;
                    if (Request.Form[kh.MK] != null)
                    {
                        model.MK = dao.EncodePassword(kh.MK);

                    }
                    con.SaveChanges();
                    return Redirect("/Home/Index");

                }
                catch
                {
                    return View();
                }

            }

            return View();
        }
    }
}