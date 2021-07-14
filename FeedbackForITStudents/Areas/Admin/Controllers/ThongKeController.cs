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
            var month = DateTime.Now.Month;
            var allCauhoi = model.CAUHOIDADUYETs.ToList();
            foreach (var item in allCauhoi)
            {
                //var thongke = model.CAUHOIDADUYETs.Where(t => t.Thoigian.Month == month).Count();
                if (item.Thoigian.Month == month)
                {
                    var chude = model.CHUDEs.ToList() ;
                    return View(chude);
                }
            }
            return View();
        }
    }
}