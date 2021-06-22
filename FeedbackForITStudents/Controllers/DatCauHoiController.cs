using FeedbackForITStudents.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedbackForITStudents.Controllers
{
    public class DatCauHoiController : Controller
    {
        SEP24Team12Entities model = new SEP24Team12Entities();
        // GET: DatCauHoi
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CAUHOI c)
        {
            var cauhoi = new CAUHOI();
            cauhoi.Noidung = c.Noidung;
            cauhoi.Andanh = c.Andanh;
            cauhoi.Thoigian = DateTime.Now;
            cauhoi.Email = HttpContext.User.Identity.GetUserName();
            cauhoi.MaTKAsp = HttpContext.User.Identity.GetUserId();
            model.CAUHOIs.Add(cauhoi);
            model.SaveChanges();
            TempData["SuccessMessage"] = "Gửi câu hỏi thành công";
            return RedirectToAction("Index", "Home");
        }
    }
}