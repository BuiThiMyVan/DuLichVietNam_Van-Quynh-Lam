using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.EF;
using PagedList;
using Web_DuLichVietNam.Models;
using Web_DuLichVietNam.Common;

namespace Web_DuLichVietNam.Controllers
{

    public class DiemDenController : Controller
    {
        private DuLichVietNamDbContext con = new DuLichVietNamDbContext();

        // GET: DiemDen       
        public ActionResult Index(int? page)
        {

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in con.TOURs select l).OrderBy(x => x.MaTour);

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 3;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Detail(int id)
        {
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
                return RedirectToAction("Detail");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult BookTour(int id)
        {
            ViewBag.Tour = con.TOURs.Find(id);
            ViewBag.LoaiPhong = con.LOAIPHONGs.ToList();
            var session = (DangNhapModel)Session[Web_DuLichVietNam.Common.CommonConstants.USER_SESSION];
            ViewBag.KhachHang = new KhachHangModel().GetByUsername(session.TenDN);           
            return View();
        }

        [HttpPost]
        public ActionResult BookTour(BookTourModel model)
        {
            ViewBag.Tour = con.TOURs.Find(model.MaTour);
            ViewBag.LoaiPhong = con.LOAIPHONGs.ToList();
            var session = (DangNhapModel)Session[Web_DuLichVietNam.Common.CommonConstants.USER_SESSION];
            ViewBag.KhachHang = new KhachHangModel().GetByUsername(session.TenDN);

            if (ModelState.IsValid)
            {
                LOAIPHONG lp = con.LOAIPHONGs.Find(model.MaLP);
                TOUR tour = con.TOURs.Find(model.MaTour);
                var tongtien = (tour.GiaTour) * (model.SoLuongNL) + (tour.GiaTour) * (model.SoLuongTE) * (tour.TiLe) + (lp.GiaPhongDoi) * (model.SoPhongDoi) + (lp.GiaPhongDon) * (model.SoPhongDon);
                model.TongTien = tongtien;
                return RedirectToAction("Payment","DiemDen", model);
            }

            return View(model);
        }

        public ActionResult Payment(BookTourModel model)
        {
            DATTOUR dattour = new DATTOUR();
            ViewBag.TourDat = con.TOURs.Find(model.MaTour);
            ViewBag.LoaiPhongDat = con.LOAIPHONGs.Find(model.MaLP);
            var session = (DangNhapModel)Session[Web_DuLichVietNam.Common.CommonConstants.USER_SESSION];
            ViewBag.KhachHangDat = new KhachHangModel().GetByUsername(session.TenDN);
            ViewBag.GiaTE = (ViewBag.TourDat.GiaTour) * (ViewBag.TourDat.TiLe);

            dattour.MaTour = model.MaTour;
            dattour.MaKH = new KhachHangModel().GetByUsername(session.TenDN).MaKH;
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

        [HttpPost]
        public ActionResult Payment(DATTOUR model)
        {
            DATTOUR dattour = new DATTOUR();
            ViewBag.TourDat = con.TOURs.Find(model.MaTour);
            ViewBag.LoaiPhongDat = con.LOAIPHONGs.Find(model.MaLP);
            var session = (DangNhapModel)Session[Web_DuLichVietNam.Common.CommonConstants.USER_SESSION];
            ViewBag.KhachHangDat = new KhachHangModel().GetByUsername(session.TenDN);
            ViewBag.GiaTE = (ViewBag.TourDat.GiaTour) * (ViewBag.TourDat.TiLe);

            var result = new DatTourModel().InsertDatTour(model);
            var tour = con.TOURs.Find(model.MaTour);
            tour.SoLuong = tour.SoLuong - 1;
            con.SaveChanges();

            if (result > 0)
            {
                ViewBag.Success = "Đặt Tour thành công!";
            }
            else
            {
                ModelState.AddModelError("", "Đặt Tour không thành công!");
            }
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

       
    }
}