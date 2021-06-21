using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackForITStudents.Models;
using System.Web.Mvc;

namespace FeedbackForITStudents.Controllers
{
    public class CauHoiCaNhanController : Controller
    {
        SEP24Team12Entities model = new SEP24Team12Entities();
        // GET: CauHoiCaNhan
        public ActionResult Index(string email)
        {
            var traloi = model.TRALOIs.FirstOrDefault(f => f.CAUHOI.TAIKHOANSV.Email == email);
            return View(traloi);
        }
    }
}