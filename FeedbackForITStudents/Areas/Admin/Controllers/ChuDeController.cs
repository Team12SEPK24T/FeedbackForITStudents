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
    public class ChuDeController : Controller
    {
        SEP24Team12Entities model = new SEP24Team12Entities();
        // GET: Admin/ChuDe
        public ActionResult Index()
        {
            var chude = model.CHUDEs.ToList();
            return View(chude);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Action = "Index";
            ViewBag.Controller = "ChuDe";
            return View();
        }

        [HttpPost]
        public ActionResult Create(CHUDE c)
        {
            var chude = new CHUDE();
            chude.TenCD = c.TenCD;
            model.CHUDEs.Add(chude);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}