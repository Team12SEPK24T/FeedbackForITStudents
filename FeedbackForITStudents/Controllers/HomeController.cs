using FeedbackForITStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedbackForITStudents.Controllers
{
    public class HomeController : Controller
    {
        SEP24Team12Entities model = new SEP24Team12Entities();
        [Authorize]
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

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}