using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webcuoiky2.Models;

namespace webcuoiky2.Controllers
{
    public class CartController : Controller
    {
        private NoiThat db = new NoiThat();
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session["Cart"] as List<SanPham>;
            return View(cart ?? new List<SanPham>());
        }
        public ActionResult AddToCart(int id)
        {
            using (var db = new NoiThat())
            {
                var product = db.SanPhams.Find(id);
                if (product != null)
                {
                    var cart = Session["Cart"] as List<SanPham> ?? new List<SanPham>();
                    cart.Add(product);
                    Session["Cart"] = cart;
                }
            }
            return RedirectToAction("Index", "Cart");

        }
        public ActionResult RemoveFromCart(int id)
        {
            var cart = Session["Cart"] as List<SanPham>;
            if (cart != null)
            {
                var itemToRemove = cart.FirstOrDefault(p => p.MaSanPham == id);
                if (itemToRemove != null)
                {
                    cart.Remove(itemToRemove);
                }
                Session["Cart"] = cart;
            }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult Checkout()
        {          
            var cart = Session["Cart"] as List<SanPham>;          
            return View(cart);
        }
        public ActionResult Thankyou()
        {
            return View();
        }
    }
}