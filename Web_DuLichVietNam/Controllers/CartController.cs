using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DuLichVietNam.EF;
using Web_DuLichVietNam.Models;

namespace Web_DuLichVietNam.Controllers
{
    public class CartController : Controller
    {
        DuLichVietNamDbContext con = new DuLichVietNamDbContext();
        private const string CartSession = "";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            { 
                list = (List<CartItem>)cart;
            }
            return View(list); 
        }

        public ActionResult AddItem(int maTour)
        {
            var Tour = con.TOURs.Find(maTour);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Tour.MaTour == maTour))
                {
                }
                else
                {
                    var item = new CartItem();
                    item.Tour = Tour;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                // tạo mới đối tượng cart item
                var item = new CartItem();
                item.Tour = Tour;
                var list = new List<CartItem>();
                list.Add(item);

                // gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}