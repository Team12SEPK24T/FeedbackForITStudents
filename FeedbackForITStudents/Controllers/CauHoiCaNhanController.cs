using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackForITStudents.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FeedbackForITStudents.Controllers
{
    [Authorize]
    public class CauHoiCaNhanController : Controller
    {
        SEP24Team12Entities model = new SEP24Team12Entities();
        // GET: CauHoiCaNhan
        //private List<TRALOI> getTraLoi()
        //{
        //    var listTraloi = model.TRALOIs;
        //    //var listIdFood = getIdFoodInTodayMenu();
        //}
        public ActionResult Index()
        {
            string userId = HttpContext.User.Identity.Name;
            var traloi = model.TRALOIs.Where(f =>f.CAUHOI.MaTKAsp == userId);
            return View(traloi);
        }
    }
}