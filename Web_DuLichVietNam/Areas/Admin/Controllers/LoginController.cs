using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.Areas.Admin.Code;
using Web_DuLichVietNam.Areas.Admin.Models;
using Web_DuLichVietNam.Models;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(LoginModel model)
        {
            var result = new AdminModel().Login(model.TenDNAdmin, model.MK);
            if(result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { TenDNAdmin = model.TenDNAdmin });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("","Tên đăng nhập hoặc mật khẩu không đúng!");
            }
            return View(model);
        }
    }
}