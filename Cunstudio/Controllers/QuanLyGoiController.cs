using Cunstudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cunstudio.Controllers
{
    public class QuanLyGoiController : Controller
    {
        // GET: QuanLyGoi
        CunstudioEntities db = new CunstudioEntities();
        public ActionResult DanhSachGoi()
        {
            return View(db.GoiDichVus);
        }
        [HttpGet]
        public ActionResult TaoMoiGoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoiGoi(GoiDichVu gdv, FormCollection f)
        {
            var G = db.GoiDichVus.FirstOrDefault(s => s.TenGoi == gdv.TenGoi);
            if (G == null)
            {
                db.GoiDichVus.Add(gdv);
                db.SaveChanges();
                return RedirectToAction("DanhSachGoi");
            }
            else
            {
                ViewBag.error = "Đã tồn tại";
                return View();
            }
        }
        [HttpGet]
        public ActionResult ChinhSuaGoi(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            GoiDichVu G = db.GoiDichVus.SingleOrDefault(n => n.Id_Goi == id);
            if (G == null)
            {
                return HttpNotFound();
            }
            return View(G);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ChinhSuaGoi(GoiDichVu model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DanhSachGoi");
        }
        [HttpGet]
        public ActionResult XoaGoi(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            GoiDichVu G = db.GoiDichVus.SingleOrDefault(n => n.Id_Goi == id);
            if (G == null)
            {
                return HttpNotFound();
            }
            return View(G);
        }
        [HttpPost]
        public ActionResult XoaGoi(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoiDichVu model = db.GoiDichVus.SingleOrDefault(n => n.Id_Goi == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.GoiDichVus.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachGoi");
        }
    }
}