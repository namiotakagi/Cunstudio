using Cunstudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cunstudio.Controllers
{
    public class ThongTinKHController : Controller
    {
        CunstudioEntities db = new CunstudioEntities();
        // GET: ThongTinKH
        [HttpGet]
        public ActionResult ThongTinKH(int? id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSuaKH(int? id)
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
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ChinhSuaKH(KhachHang model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ThongTinKH");
        }
    }
}