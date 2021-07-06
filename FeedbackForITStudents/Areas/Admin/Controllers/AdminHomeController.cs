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
            var cauTraLoi = model.TRALOIs.ToList();
            var cauHoi = model.CAUHOIDADUYETs.ToList();

            return View(cauTraLoi);
        }
    }
}