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
    public class XemCauHoiController : Controller
    {
        // GET: Admin/XemCauHoi
        SEP24Team12Entities model = new SEP24Team12Entities();
        public ActionResult Index()
        {
            var cauhoid = model.CAUHOIDADUYETs.OrderByDescending(c => c.pin == true);
            return View(cauhoid);
        }
    }
}