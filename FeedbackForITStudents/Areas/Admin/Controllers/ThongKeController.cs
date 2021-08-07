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
    public class ThongKeController : Controller
    {
        SEP24Team12Entities model = new SEP24Team12Entities();
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            var chude = model.CHUDEs.ToList() ;
            return View(chude);
        }
    }
}