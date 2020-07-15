using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cunstudio.Models;
using PagedList;

namespace Cunstudio.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        CunstudioEntities db = new CunstudioEntities();
        [HttpGet]
        public ActionResult AlbumACB(int? page)
        {
            var LstACB = db.Anhs.Where(n => n.ID_Album == 1 && n.HienThi == true);
            int PageSize = 4;
            int PageNumber = (page ?? 1);
            return View(LstACB.OrderBy(n=>n.ID_Anh).ToPagedList(PageNumber,PageSize));
        }
        public ActionResult AlbumASS(int? page)
        {
            var LstASS = db.Anhs.Where(n => n.ID_Album == 2 && n.HienThi == true);
            int PageSize = 4;
            int PageNumber = (page ?? 1);
            return View(LstASS.OrderBy(n => n.ID_Anh).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult AlbumAGD(int? page)
        {
            var LstAGD = db.Anhs.Where(n => n.ID_Album == 3 && n.HienThi == true);
            int PageSize = 4;
            int PageNumber = (page ?? 1);
            return View(LstAGD.OrderBy(n => n.ID_Anh).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult AlbumAB(int? page)
        {
            var LstAB = db.Anhs.Where(n => n.ID_Album == 4 && n.HienThi == true);
            int PageSize = 4;
            int PageNumber = (page ?? 1);
            return View(LstAB.OrderBy(n => n.ID_Anh).ToPagedList(PageNumber, PageSize));
        }

    }
}