using Cunstudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cunstudio.Controllers
{
    public class QuanLyHDController : Controller
    {
        CunstudioEntities db = new CunstudioEntities();
        // GET: QuanLyHD
        public ActionResult DanhSachHD()
        {
            return View(db.HopDongs);
        }
        [HttpGet]
        public ActionResult TaoMoiHD()
        {
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs.OrderBy(n => n.Ten), "ID_KhachHang", "Ten");
            ViewBag.ID_Admin = new SelectList(db.Admins.OrderBy(n => n.Ten), "ID_Admin", "Ten");
            ViewBag.ID_Goi = new SelectList(db.GoiDichVus.OrderBy(n => n.TenGoi), "ID_Goi", "TenGoi");
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult TaoMoiHD(HopDong HD, FormCollection f)
        {
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs.OrderBy(n => n.Ten), "ID_KhachHang", "Ten");
            ViewBag.ID_Admin = new SelectList(db.Admins.OrderBy(n => n.Ten), "ID_Admin", "Ten");
            ViewBag.ID_Goi = new SelectList(db.GoiDichVus.OrderBy(n => n.TenGoi), "ID_Goi", "TenGoi");
            db.HopDongs.Add(HD);
            db.SaveChanges();
            return RedirectToAction("TaoMoiHD");
        }
        [HttpGet]
        public ActionResult ChinhSuaHD(int? id)
        {
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs.OrderBy(n => n.Ten), "ID_KhachHang", "Ten");
            ViewBag.ID_Admin = new SelectList(db.Admins.OrderBy(n => n.Ten), "ID_Admin", "Ten");
            ViewBag.ID_Goi = new SelectList(db.GoiDichVus.OrderBy(n => n.TenGoi), "ID_Goi", "TenGoi");
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            HopDong hd = db.HopDongs.SingleOrDefault(n => n.ID_HopDong == id);
            if (hd == null)
            {
                return HttpNotFound();
            }
            return View(hd);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ChinhSuaGoi(HopDong model)
        {
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs.OrderBy(n => n.Ten), "ID_KhachHang", "Ten");
            ViewBag.ID_Admin = new SelectList(db.Admins.OrderBy(n => n.Ten), "ID_Admin", "Ten");
            ViewBag.ID_Goi = new SelectList(db.GoiDichVus.OrderBy(n => n.TenGoi), "ID_Goi", "TenGoi");
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DanhSachHD");
        }
        public ActionResult XoaHD(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            HopDong hd = db.HopDongs.SingleOrDefault(n => n.ID_HopDong == id);
            if (hd == null)
            {
                return HttpNotFound();
            }
            return View(hd);
        }
        [HttpPost]
        public ActionResult XoaHD(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDong model = db.HopDongs.SingleOrDefault(n => n.ID_HopDong == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.HopDongs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachHD");
        }
    }

}