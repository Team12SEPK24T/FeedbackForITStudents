using FeedbackForITStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebCanteen.Areas.Admin.Middleware;

namespace FeedbackForITStudents.Areas.Admin.Controllers
{
    [LoginVerification]
    public class DuyetCauHoiController : Controller
    {
        // GET: Admin/DuyetCauHoi
        SEP24Team12Entities model = new SEP24Team12Entities();
        public ActionResult Index()
        {
            var cauhoi = model.CAUHOIs.ToList();
            return View(cauhoi);
        }
        [HttpPost]
        public ActionResult Browse(int id, CAUHOIDADUYET d)
        {
            if (Request["delete"] != null)
            {

                var cauhoi = model.CAUHOIs.FirstOrDefault(f => f.MaCH == id);
                model.CAUHOIs.Remove(cauhoi);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (Request["duyet"] != null)
            {
                CAUHOI cauhoi = model.CAUHOIs.Find(id);
                var cauhoid = new CAUHOIDADUYET { Noidung = cauhoi.Noidung, Andanh = cauhoi.Andanh, Thoigian = cauhoi.Thoigian, Email = cauhoi.Email, MaTKAsp = cauhoi.MaTKAsp};
                cauhoid.pin = d.pin;
                cauhoid.Rep = false;
                cauhoid.MaCD = cauhoi.MaCD;
                model.CAUHOIDADUYETs.Add(cauhoid);
                model.CAUHOIs.Remove(cauhoi);
                model.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
    }
}