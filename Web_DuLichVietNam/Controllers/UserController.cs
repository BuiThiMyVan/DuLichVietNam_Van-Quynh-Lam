using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.Common;
using Web_DuLichVietNam.EF;
using Web_DuLichVietNam.Models;

namespace Web_DuLichVietNam.Controllers
{
    public class UserController : Controller
    {
        DuLichVietNamDbContext con = new DuLichVietNamDbContext();

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(DangNhapModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new KhachHangModel();
                var result = dao.Login(model.TenDN, dao.EncodePassword(model.MK));
                if(result)
                {
                    var kh = dao.GetByUsername(model.TenDN);
                    var userSession = new DangNhapModel();
                    userSession.TenDN = kh.TenDN;
                    userSession.MaKH = kh.MaKH;
                    userSession.MK = kh.MK;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
            }
            return View(model);
        }
        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangModel();
                if(dao.CheckUserName(model.TenDN))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if(dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var kh = new KHACHHANG();
                    kh.TenDN = model.TenDN;
                    kh.MK = dao.EncodePassword(model.MK);
                    kh.SDT = model.SDT;
                    kh.Email = model.Email;
                    kh.GioiTinh = model.GioiTinh;
                    kh.NgaySinh = model.NgaySinh;
                    kh.TenKH = model.TenKH;
                    kh.MaQuyen = 2;
                    var result = dao.Insert(kh);
                    if(result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công!";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }


                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/Home/Index");
        }
    }
}