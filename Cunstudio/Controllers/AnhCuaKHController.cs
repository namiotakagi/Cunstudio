using Cunstudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Cunstudio.Controllers
{
    public class AnhCuaKHController : Controller
    {
        CunstudioEntities db = new CunstudioEntities();
        // GET: KH
        [HttpGet]
        public ActionResult XemAnh(int? id, int? page)
        {
            var lstA = db.Anhs.Where(n => n.ID_KhachHang == id);
            int PageSize = 4;
            int PageNumber = (page ?? 1);
            return View(lstA.OrderBy(n => n.ID_Anh).ToPagedList(PageNumber, PageSize));
        }
        [HttpGet]
        public ActionResult YeuCaupartial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeuCaupartial(SuaAnhTheoYC yc, FormCollection f)
        {
            db.SuaAnhTheoYCs.Add(yc);
            db.SaveChanges();
            return RedirectToAction("XemAnh");
        }
    }
}