using FeedbackForITStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCanteen.Areas.Admin.Middleware;

namespace FeedbackForITStudents.Areas.Admin.Controllers
{
    [LoginVerification]
    public class AdminHomeController : Controller
    {
        SEP24Team12Entities model = new SEP24Team12Entities();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            var cauhoi = model.CAUHOIDADUYETs.ToList();
            var traloi = model.TRALOIs.OrderByDescending(t => t.MaCTL);
            return View(traloi);
        }
        [HttpPost]
        public ActionResult Like(int id, TRALOI t)
        {
            TRALOI updateTim = model.TRALOIs.FirstOrDefault(u => u.MaCTL == id);
            if (Request["like"] != null)
            {
                updateTim.Luottim++;
            }
            model.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}