using Cunstudio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cunstudio.Controllers
{
    public class QuanLyAnhController : Controller
    {
        CunstudioEntities db = new CunstudioEntities();
        public ActionResult DanhSachAnh()
        {
            return View(db.Anhs);
        }
        [HttpGet]
        public ActionResult ThemAnh()
        {
            ViewBag.ID_Album = new SelectList(db.Albums.OrderBy(n => n.TenAlbum), "ID_Album", "TenAlbum");
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs.OrderBy(n => n.Ten), "ID_KhachHang", "Ten");
            ViewBag.ID_Admin = new SelectList(db.Admins.OrderBy(n => n.Ten), "ID_Admin", "Ten");
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ThemAnh(Anh a, HttpPostedFileBase HinhAnh)
        {
            ViewBag.ID_Album = new SelectList(db.Albums.OrderBy(n => n.TenAlbum), "ID_Album", "TenAlbum");
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs.OrderBy(n => n.Ten), "ID_KhachHang", "Ten");
            ViewBag.ID_Admin = new SelectList(db.Admins.OrderBy(n => n.Ten), "ID_Admin", "Ten");
            if (HinhAnh.ContentLength > 0)
            {
                var fileName = Path.GetFileName(HinhAnh.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Image"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.upload = "Đã tồn tại";
                }
                else
                {
                    HinhAnh.SaveAs(path);
                    a.HinhAnh = fileName;
                }
            }
            db.Anhs.Add(a);
            db.SaveChanges();
            return RedirectToAction("DanhSachAnh");
        }
        [HttpGet]
        public ActionResult ChinhSuaAnh(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            Anh a = db.Anhs.SingleOrDefault(n => n.ID_Anh == id);
            if (a == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Album = new SelectList(db.Albums.OrderBy(n => n.TenAlbum), "ID_Album", "TenAlbum", a.ID_Album);
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs.OrderBy(n => n.Ten), "ID_KhachHang", "Ten", a.ID_KhachHang);
            ViewBag.ID_Admin = new SelectList(db.Admins.OrderBy(n => n.Ten), "ID_Admin", "Ten", a.ID_Admin);
            return View(a);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ChinhSuaAnh(Anh model, HttpPostedFileBase HinhAnh)
        {
            ViewBag.ID_Album = new SelectList(db.Albums.OrderBy(n => n.TenAlbum), "ID_Album", "TenAlbum", model.ID_Album);
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs.OrderBy(n => n.Ten), "ID_KhachHang", "Ten", model.ID_KhachHang);
            ViewBag.ID_Admin = new SelectList(db.Admins.OrderBy(n => n.Ten), "ID_Admin", "Ten", model.ID_Admin);
            if (HinhAnh.ContentLength > 0)
            {
                var fileName = Path.GetFileName(HinhAnh.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Image"), fileName);
                HinhAnh.SaveAs(path);
                model.HinhAnh = fileName;
            }
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DanhSachAnh");
        }
        [HttpGet]
        public ActionResult XoaAnh(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            Anh a = db.Anhs.SingleOrDefault(n => n.ID_Anh == id);
            if (a == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Album = new SelectList(db.Albums.OrderBy(n => n.TenAlbum), "ID_Album", "TenAlbum", a.ID_Album);
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs.OrderBy(n => n.Ten), "ID_KhachHang", "Ten", a.ID_KhachHang);
            ViewBag.ID_Admin = new SelectList(db.Admins.OrderBy(n => n.Ten), "ID_Admin", "Ten", a.ID_Admin);
            return View(a);
        }
        [HttpPost]
        public ActionResult XoaAnh(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anh model = db.Anhs.SingleOrDefault(n => n.ID_Anh == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.Anhs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachAnh");
        }
        public ActionResult AlbumACB()
        {
            return View(db.Anhs.Where(n => n.ID_Album == 1 && n.HienThi == true).Take(5).ToList());
        }
        public ActionResult AlbumASS()
        {
            return View(db.Anhs.Where(n => n.ID_Album == 2 && n.HienThi == true).Take(5).ToList());
        }
        public ActionResult AlbumAGD()
        {
            return View(db.Anhs.Where(n => n.ID_Album == 3 && n.HienThi == true).Take(5).ToList());
        }
        public ActionResult AlbumAB()
        {
            return View(db.Anhs.Where(n => n.ID_Album == 4 && n.HienThi == true).Take(5).ToList());
        }
    }
}