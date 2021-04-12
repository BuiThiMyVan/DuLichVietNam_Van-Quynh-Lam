using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.Areas.Admin.Models;
using Web_DuLichVietNam.Framework;

namespace Web_DuLichVietNam.Areas.Admin.Controllers
{
    public class HDVController : Controller
    {
        // GET: Admin/HDV
        public ActionResult Index()
        {
            var iplKhach = new HDVModel();
            var model = iplKhach.ListAll();
            return View(model);
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
        public ActionResult Create(HUONGDANVIEN collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new HDVModel();
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
            var user = new HDVModel().ViewDetail(id);
            return View(user);
        }

        // POST: Admin/Khach/Edit/5
        [HttpPost]
        public ActionResult Edit(HUONGDANVIEN hdv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new HDVModel();
                    //long res = model.Create(collection.TenKH, collection.NgaySinh, collection.GioiTinh, collection.SDT, collection.Email, collection.TenDN, collection.MK, collection.MaQuyen);
                    var res = model.Update(hdv);
                    // TODO: Add insert logic here
                    if (res)
                    {
                        return RedirectToAction("Index", "HDV");
                    }    //return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công");
                    }
                }
                return View(hdv);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id, Web_DuLichVietNam.Areas.Admin.Models.HDVModel deletemodel)
        {
            int records = deletemodel.Delete(id);
            if (records > 0)
            {
                return RedirectToAction("Index", "HDV");
            }
            else
            {
                ModelState.AddModelError("", "Can Not Delete");
                return View("Index", "Khach");
            }
        }
    }
}