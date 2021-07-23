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
        [HttpGet]
        public ActionResult Index()
        {
            var userIdentity = User.Identity.GetUserId();
            var allCauhoi = model.CAUHOIDADUYETs.ToList();
            foreach (var item in allCauhoi)
            {
                if(userIdentity == item.MaTKAsp)
                {
                    var cauhoi = model.TRALOIs.Where(c => c.CAUHOIDADUYET.MaTKAsp == userIdentity).ToList();
                    var canhand = cauhoi.OrderByDescending(d => d.MaCTL);
                    return View(canhand);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Like(int id, TRALOI t)
        {
            TRALOI updateTim = model.TRALOIs.FirstOrDefault(u => u.MaCTL == id);
            if (Request["like"] != null)
            {
                updateTim.Luottim++;
            }
            model.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}