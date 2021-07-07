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
        [HttpGet]
        public ActionResult Reply(int id)
        {
            CAUHOIDADUYET cauhoi = model.CAUHOIDADUYETs.FirstOrDefault(a => a.MaCHD == id);
            ViewBag.Action = "Index";
            ViewBag.Controller = "XemCauHoi";
            return View(cauhoi);
        }
        [HttpPost]
        public ActionResult Reply(int id, TRALOI reply)
        {
            //ValidateReply(reply);
            if (ModelState.IsValid)
            {
                var cauhoi = model.CAUHOIDADUYETs.FirstOrDefault(c => c.MaCHD == id);
                var traloi = new TRALOI();
                if (String.IsNullOrWhiteSpace(reply.Noidungtraloi))
                {
                    ViewBag.Message = "Vui long nhap cau hoi";
                    return View();
                }
                else
                {
                    traloi.Noidungtraloi = reply.Noidungtraloi;
                    traloi.Thoigian = DateTime.Today;
                    traloi.MaTK = (int)Session["user-id"];
                    traloi.Luottim = 0;
                    traloi.MaCHD = cauhoi.MaCHD;
                    model.TRALOIs.Add(traloi);
                    cauhoi.Rep = true;
                    model.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Action = "Index";
            ViewBag.Controller = "XenCauHoi";
            return View(reply);
        }

        private void ValidateReply(TRALOI reply)
        {
            if (String.IsNullOrWhiteSpace(reply.Noidungtraloi))
            {
                ModelState.AddModelError("Noidungtraloi", "Vui lòng nhập câu trả lời");
            }
        }
    }
}