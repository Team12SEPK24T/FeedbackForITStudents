using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCanteen.Areas.Admin.Middleware;
using FeedbackForITStudents.Models;

namespace FeedbackForITStudents.Areas.Admin.Controllers
{
    [LoginVerification]
    public class XemCauHoiController : Controller
    {
        SEP24Team12Entities model = new SEP24Team12Entities();
        // GET: Admin/XemCauHoi
        public ActionResult Index()
        {
            var cauhoid = model.CAUHOIDADUYETs.OrderByDescending(c => c.pin == true);
            return View(cauhoid);
        }
        [HttpGet]
        public ActionResult Reply(int id)
        {
            CAUHOIDADUYET cauhoi = model.CAUHOIDADUYETs.FirstOrDefault(a => a.MaCHD == id);
            ViewBag.Action = "Index";
            ViewBag.Controller = "XemCauHoi";
            return View(cauhoi);
        }
        [HttpPost]
        public ActionResult Reply(int id, TRALOI t)
        {
            var cauhoi = model.CAUHOIDADUYETs.FirstOrDefault(c => c.MaCHD == id);
            var traloi = new TRALOI();
            traloi.Noidungtraloi = t.Noidungtraloi;
            traloi.Thoigian = DateTime.Today;
            traloi.MaTK = (int)Session["user-id"];
            traloi.Luottim = 0;
            traloi.MaCHD = cauhoi.MaCHD;
            model.TRALOIs.Add(traloi);
            cauhoi.Rep = true;
            model.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}