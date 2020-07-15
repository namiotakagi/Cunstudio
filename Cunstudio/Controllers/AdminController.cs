using Cunstudio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cunstudio.Controllers
{
    public class AdminController : Controller
    {
        CunstudioEntities db = new CunstudioEntities();
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["username"].ToString();
            string sMatKhau = f["pass"].ToString();
            Admin Am = db.Admins.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (Am != null)
            {
                Session["username"] = Am;
                return RedirectToAction("IndexAdmin");
            }
            return RedirectToAction("Login");
        }
        public ActionResult DangXuat()
        {
            Session["username"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult GopYKH()
        {
            return View(db.GopYKHs);
        }

    }
}