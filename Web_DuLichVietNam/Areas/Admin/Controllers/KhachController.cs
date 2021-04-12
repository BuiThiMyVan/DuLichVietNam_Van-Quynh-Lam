using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.Areas.Admin.Models;
using Web_DuLichVietNam.Framework;
using Web_DuLichVietNam.Models;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class KhachController : Controller
    {

        // GET: Admin/Khach
        public ActionResult Index()
        {
            var iplKhach = new KhachModel();
            var model = iplKhach.ListAll();
            return View(model);
        }

        // GET: Admin/Khach/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Khach/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Khach/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KHACHHANG collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new KhachModel();
                    //long res = model.Create(collection.TenKH, collection.NgaySinh, collection.GioiTinh, collection.SDT, collection.Email, collection.TenDN, collection.MK, collection.MaQuyen);
                    long res = model.Insert(collection);
                    // TODO: Add insert logic here
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }    //return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới không thành công");
                    }
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Khach/Edit/5
        public ActionResult Edit(int id)
        {
            var user = new KhachModel().ViewDetail(id);
            return View(user);
        }

        // POST: Admin/Khach/Edit/5
        [HttpPost]
        public ActionResult Edit(KHACHHANG khachhang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new KhachModel();
                    //long res = model.Create(collection.TenKH, collection.NgaySinh, collection.GioiTinh, collection.SDT, collection.Email, collection.TenDN, collection.MK, collection.MaQuyen);
                    var res = model.Update(khachhang);
                    // TODO: Add insert logic here
                    if (res)
                    {
                        return RedirectToAction("Index", "Khach");
                    }    //return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công");
                    }
                }
                return View(khachhang);
            }
            catch
            {
                return View();
            }
        }

        //GET: Admin/Khach/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    var user = new KhachModel().ViewDetail(id);

        //    return View(user);
        //}

        //// POST: Admin/Khach/Delete/5
        //[HttpPost]
        //public ActionResult Delete(KHACHHANG khachhang)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var model = new KhachModel();
        //            var res = model.Delete(khachhang);
        //            // TODO: Add insert logic here
        //            if (res)
        //            {
        //                return RedirectToAction("Index", "Khach");
        //            }    //return RedirectToAction("Index");
        //            else
        //            {
        //                ModelState.AddModelError("", "Xóa không thành công");
        //            }
        //        }
        //        return View(khachhang);
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    new KhachModel().Delete(id);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult Delete(int id, Web_DuLichVietNam.Areas.Admin.Models.KhachModel deletemodel)
        {
            int records = deletemodel.Delete(id);
            if (records > 0)
            {
                return RedirectToAction("Index", "Khach");
            }
            else
            {
                ModelState.AddModelError("", "Can Not Delete");
                return View("Index", "Khach");
            }
        }
    }
}
