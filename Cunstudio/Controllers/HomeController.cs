using Cunstudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cunstudio.Controllers
{
    public class HomeController : Controller
    {
        CunstudioEntities db = new CunstudioEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult CacGoiChup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["username"].ToString();
            string sMatKhau = f["pass"].ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (kh != null) 
            {
                Session["username"] = kh;
                Session["idkh"] = kh.Id_KhachHang;
                return RedirectToAction ("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult DangXuat()
        {
            Session["username"] = null;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GopYKHpartial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GopYKHpartial(GopYKH gy , FormCollection f )
        {
            db.GopYKHs.Add(gy);
            db.SaveChanges();
            return RedirectToAction("LienHe");
        }
        public ActionResult ACBpartial()
        {
            return View();
        }
        public ActionResult ASSpartial()
        {
            return View();
        }
        public ActionResult AGDpartial()
        {
            return View();
        }
    }
}

