using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webcuoiky2.Models;

namespace webcuoiky2.Controllers
{
    public class ChiTietDatHangsController : Controller
    {
        private NoiThat db = new NoiThat();

        // GET: ChiTietDatHangs
        public ActionResult Index()
        {
            var chiTietDatHangs = db.ChiTietDatHangs.Include(c => c.DonDatHang).Include(c => c.SanPham);
            return View(chiTietDatHangs.ToList());
        }

        // GET: ChiTietDatHangs/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
        //    if (chiTietDatHang == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(chiTietDatHang);
        //}
        public ActionResult Details(int? SoHoaDon, int? MaSanPham)
        {
            if (SoHoaDon == null || MaSanPham == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(SoHoaDon, MaSanPham);
            if (chiTietDatHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDatHang);
        }

        // GET: ChiTietDatHangs/Create
        public ActionResult Create()
        {
            ViewBag.SoHoaDon = new SelectList(db.DonDatHangs, "SoDonHang", "TenNguoiNhan");
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: ChiTietDatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoHoaDon,MaSanPham,SoLuong,DonGia")] ChiTietDatHang chiTietDatHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDatHangs.Add(chiTietDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SoHoaDon = new SelectList(db.DonDatHangs, "SoDonHang", "TenNguoiNhan", chiTietDatHang.SoHoaDon);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietDatHang.MaSanPham);
            return View(chiTietDatHang);
        }

        // GET: ChiTietDatHangs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
        //    if (chiTietDatHang == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.SoHoaDon = new SelectList(db.DonDatHangs, "SoDonHang", "TenNguoiNhan", chiTietDatHang.SoHoaDon);
        //    ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietDatHang.MaSanPham);
        //    return View(chiTietDatHang);
        //}
        public ActionResult Edit(int? SoHoaDon, int? MaSanPham)
        {
            if (SoHoaDon == null || MaSanPham == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(SoHoaDon, MaSanPham);
            if (chiTietDatHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDatHang);
        }

        // POST: ChiTietDatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "SoHoaDon,MaSanPham,SoLuong,DonGia")] ChiTietDatHang chiTietDatHang)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(chiTietDatHang).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.SoHoaDon = new SelectList(db.DonDatHangs, "SoDonHang", "TenNguoiNhan", chiTietDatHang.SoHoaDon);
        //    ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietDatHang.MaSanPham);
        //    return View(chiTietDatHang);
        //}
        public ActionResult Edit([Bind(Include = "SoHoaDon,MaSanPham,SoLuong,DonGia")] ChiTietDatHang chiTietDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietDatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiTietDatHang);
        }


        // GET: ChiTietDatHangs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
        //    if (chiTietDatHang == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(chiTietDatHang);
        //}
        public ActionResult Delete(int? SoHoaDon, int? MaSanPham)
        {
            if (SoHoaDon == null || MaSanPham == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(SoHoaDon, MaSanPham);
            if (chiTietDatHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDatHang);
        }

        // POST: ChiTietDatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
        //    db.ChiTietDatHangs.Remove(chiTietDatHang);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult DeleteConfirmed(int SoHoaDon, int MaSanPham)
        {
            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(SoHoaDon, MaSanPham);
            db.ChiTietDatHangs.Remove(chiTietDatHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
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
