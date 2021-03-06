    using FeedbackForITStudents.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<ActionResult> Index(int? id)
        {
            var cauhoid = model.CAUHOIDADUYETs.OrderByDescending(c => c.pin == true);
            ViewBag.ChuDe = new SelectList(model.CHUDEs, "MaCD", "TenCD");
            var chude = model.CHUDEs.ToList();
                if (id != null)
                {
                    return View(await model.CAUHOIDADUYETs.Where(x => x.MaCD == id).ToListAsync());
                }
            return View(cauhoid);
        }

        [HttpGet]
        public ActionResult Filter(int id)
        {
            ViewBag.ChuDe = new SelectList(model.CHUDEs, "MaCD", "TenCD");
            var locCauHoi = model.CAUHOIDADUYETs.Where(f => f.MaCD == id).ToList();
            var cauhoid = locCauHoi.OrderByDescending(c => c.pin == true);
            //var cauhoid = model.CAUHOIDADUYETs.OrderByDescending(c => c.MaCD == id);
            ViewBag.Action = "Index";
            ViewBag.Controller = "XemCauHoi";
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
            ViewBag.Action = "Index";
            ViewBag.Controller = "XenCauHoi";
            return View(reply);
        }

    }
}