using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webcuoiky2.Models;

namespace webcuoiky2.Controllers
{
    public class LoginController : Controller
    {
        private NoiThat db = new NoiThat();

        // GET: Login
        public ActionResult LoginKh()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginKh(string tdn, string mk)
        { // Kiểm tra tài khoản và mật khẩu
            var admin = db.KhachHangs.FirstOrDefault(a => a.TenDangNhap == tdn && a.MatKhau == mk);
            if (admin != null)
            {
                // Nếu đúng tài khoản và mật khẩu, điều hướng tới trang quản trị
                return RedirectToAction("Index", "Test");
            }
            else
            {
                // Nếu sai tài khoản hoặc mật khẩu, hiển thị thông báo lỗi
                ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng";
                return View();
            }
        }
        public ActionResult Lclogin()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string tdn, string mk)
        { // Kiểm tra tài khoản và mật khẩu
            var admin = db.Admins.FirstOrDefault(a => a.TenDangNhap == tdn && a.MatKhau == mk);
            if (admin != null)
            {
                // Nếu đúng tài khoản và mật khẩu, điều hướng tới trang quản trị
                return RedirectToAction("Index", "TrangQT");
            }
            else
            {
                // Nếu sai tài khoản hoặc mật khẩu, hiển thị thông báo lỗi
                ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng";
                return View();
            }
        }
        public ActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                
                var existingKhachHang = db.KhachHangs.FirstOrDefault(k => k.TenDangNhap == khachHang.TenDangNhap);
                if (existingKhachHang == null)
                {
                    db.KhachHangs.Add(khachHang);
                    db.SaveChanges();
                    return RedirectToAction("LoginKh", "Login"); 
                }
                else
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại";
                }
            }
            return View(khachHang);
        }
        //public ActionResult SingUp(string TenKhach, string DiaChi, string SoDienThoai, string TenDangNhap, string MatKhau, DateTime NgaySinh, string GioiTinh, string Email)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var existingUser = db.KhachHangs.FirstOrDefault(kh => kh.TenDangNhap == TenDangNhap);
        //        if (existingUser != null)
        //        {
        //            ViewBag.Error = "Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.";
        //            return View();
        //        }


        //        var newKhachHang = new KhachHang
        //        {
        //            TenKhach = TenKhach,
        //            DiaChi = DiaChi,
        //            SoDienThoai = SoDienThoai,
        //            TenDangNhap = TenDangNhap,
        //            MatKhau = MatKhau, 
        //            NgaySinh = NgaySinh,
        //            GioiTinh = GioiTinh,
        //            Email = Email
        //        };

        //        try
        //        {
        //            db.KhachHangs.Add(newKhachHang);
        //            db.SaveChanges();
        //            ViewBag.Success = "Đăng ký thành công!";
        //            return RedirectToAction("LoginKh", "Login"); 
        //        }
        //        catch (Exception ex)
        //        {
        //            ViewBag.Error = "Đã xảy ra lỗi trong quá trình đăng ký: " + ex.Message;
        //        }
        //    }
        //    return View();
        //}
    }
}
        
  