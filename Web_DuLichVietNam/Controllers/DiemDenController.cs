using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.EF;
using PagedList;
namespace Web_DuLichVietNam.Controllers
{

    public class DiemDenController : Controller
    {
        // GET: DiemDen
        private DuLichVietNamDbContext con = new DuLichVietNamDbContext();

        //public ActionResult Index()
        //{
        
        //    var model = con.TOURs.ToList();

        //    return View(model);
        //}
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