using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using webcuoiky2.Models;

namespace webcuoiky2.Controllers
{
    public class SanPhamsController : Controller
    {
        private NoiThat db = new NoiThat();

        // GET: SanPhams
        
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.Hang).Include(s => s.LoaiSanPham).Include(s => s.NhaCungCap);
            return View(sanPhams.ToList());
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaHang = new SelectList(db.Hangs, "MaHang", "TenHang");
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "TenLoai");
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,Gia,NgaySanXuat,MoTa,AnhMinhHoa,MaNhaCungCap,MaHang,MaLoai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
               // Bước 1: Giải mã HTML Entities
                //string decodedMoTa = HttpUtility.HtmlDecode(sanPham.MoTa);

                // Bước 2: Loại bỏ các thẻ HTML
                //sanPham.MoTa = StripHtmlTags(decodedMoTa);
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHang = new SelectList(db.Hangs, "MaHang", "TenHang", sanPham.MaHang);
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", sanPham.MaNhaCungCap);
            return View(sanPham);
        }
        // Hàm loại bỏ các thẻ HTML
        //private string StripHtmlTags(string input)
        //{
        //    if (string.IsNullOrEmpty(input)) return string.Empty;

            
        //    return Regex.Replace(input, "<.*?>", string.Empty);
        //}
        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHang = new SelectList(db.Hangs, "MaHang", "TenHang", sanPham.MaHang);
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", sanPham.MaNhaCungCap);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenSanPham,Gia,NgaySanXuat,MoTa,AnhMinhHoa,MaNhaCungCap,MaHang,MaLoai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                // Bước 1: Giải mã HTML Entities
                //string decodedMoTa = HttpUtility.HtmlDecode(sanPham.MoTa);

                // Bước 2: Loại bỏ các thẻ HTML
                //sanPham.MoTa = StripHtmlTags(decodedMoTa);
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHang = new SelectList(db.Hangs, "MaHang", "TenHang", sanPham.MaHang);
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "MaLoai", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", sanPham.MaNhaCungCap);
            return View(sanPham);
        }
        //private string StripHtml(string input)
        //{
        //    if (string.IsNullOrEmpty(input)) return string.Empty;

            
        //    return Regex.Replace(input, "<.*?>", string.Empty);
        //}
        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult LoadProducts()
        //{
        //    var products = db.SanPhams.ToList();
        //    return PartialView("_ProductList", products);
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
