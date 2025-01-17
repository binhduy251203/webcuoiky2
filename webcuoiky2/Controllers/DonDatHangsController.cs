﻿using System;
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
    public class DonDatHangsController : Controller
    {
        private NoiThat db = new NoiThat();

        // GET: DonDatHangs
        public ActionResult Index()
        {
            var donDatHangs = db.DonDatHangs.Include(d => d.KhachHang);
            return View(donDatHangs.ToList());
        }

        // GET: DonDatHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // GET: DonDatHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaKhach = new SelectList(db.KhachHangs, "MaKhach", "TenKhach");
            return View();
        }

        // POST: DonDatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoDonHang,NgayDatHang,TriGia,NgayGiao,TenNguoiNhan,DiaChiNhan,SoDienThoaiNhan,HinhThucThanhToan,HinhThucGiaoHang,MaKhach")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.DonDatHangs.Add(donDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhach = new SelectList(db.KhachHangs, "MaKhach", "TenKhach", donDatHang.MaKhach);
            return View(donDatHang);
        }

        // GET: DonDatHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhach = new SelectList(db.KhachHangs, "MaKhach", "TenKhach", donDatHang.MaKhach);
            return View(donDatHang);
        }

        // POST: DonDatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoDonHang,NgayDatHang,TriGia,NgayGiao,TenNguoiNhan,DiaChiNhan,SoDienThoaiNhan,HinhThucThanhToan,HinhThucGiaoHang,MaKhach")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donDatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhach = new SelectList(db.KhachHangs, "MaKhach", "TenKhach", donDatHang.MaKhach);
            return View(donDatHang);
        }

        // GET: DonDatHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // POST: DonDatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            db.DonDatHangs.Remove(donDatHang);
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
