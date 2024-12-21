using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webcuoiky2.Models;

namespace webcuoiky2.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        private NoiThat db = new NoiThat(); // Kết nối cơ sở dữ liệu

        // Action hiển thị trang chủ
        
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.ToList();
            return View(sanPhams); // Truyền danh sách sản phẩm vào View
        }
        public ActionResult Details(int id)
        {
            var sach = from s in db.SanPhams where s.MaSanPham == id select s;
            return View(sach.Single());
            
        }
    }
}