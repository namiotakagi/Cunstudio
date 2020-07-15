using Cunstudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cunstudio.Controllers
{
    public class QuanLyKHController : Controller
    {
        CunstudioEntities db = new CunstudioEntities();
        public ActionResult DanhSachKH()
        {
            return View(db.KhachHangs);
        }
        [HttpGet]
        public ActionResult TaoMoiKH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoiKH(KhachHang kh, FormCollection f)
        {
            var KT = db.KhachHangs.FirstOrDefault(s => s.TaiKhoan == kh.TaiKhoan);
            if (KT == null)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DanhSachKH");
            }
            else
            {
                ViewBag.error = "Đã tồn tại";
                return View();
            }
        }
        [HttpGet]
        public ActionResult XoaKH(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            KhachHang a = db.KhachHangs.SingleOrDefault(n => n.Id_KhachHang == id);
            if (a == null)
            {
                return HttpNotFound();
            }            
            return View(a);
        }
        [HttpPost]
        public ActionResult XoaKH(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang model = db.KhachHangs.SingleOrDefault(n => n.Id_KhachHang == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.KhachHangs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachKH");
        }

        //public ActionResult Xoa()
        //{
        //    return View();
        //}



    }
    
}