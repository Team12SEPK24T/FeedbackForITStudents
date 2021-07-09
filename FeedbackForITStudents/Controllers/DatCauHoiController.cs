using FeedbackForITStudents.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedbackForITStudents.Controllers
{
    [Authorize]
    public class DatCauHoiController : Controller
    {
        SEP24Team12Entities model = new SEP24Team12Entities();
        // GET: DatCauHoi
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ChuDe = new SelectList(model.CHUDEs, "MaCD", "TenCD");
            //ViewBag.Chude = model.CHUDEs.OrderByDescending(x => x.MaCD).ToList();
            ViewBag.Action = "Index";
            ViewBag.Controller = "DatCauHoi";
            return View();
        }
      
        [HttpPost]
        public ActionResult Index(CAUHOI c)
        {
            ViewBag.ChuDe = new SelectList(model.CHUDEs, "MaCD", "TenCD");
            var userIdentity = User.Identity.GetUserId();
                var allCauhoi = model.CAUHOIs.ToList();
                var today = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                foreach (var item in allCauhoi)
                {
                    var SLcauhoi = model.CAUHOIs.Where(h => h.MaTKAsp == userIdentity && h.Thoigian == today).Count();
                    if (SLcauhoi >= 3)
                    {
                        ViewBag.Message = "Ban da het luot dat cau hoi trong hom nay! Vi ban chi dat duoc toi da 3 cau hoi moi ngay.";
                        return View();

                    }
                    else if (String.IsNullOrWhiteSpace(c.Noidung))
                    {
                        ModelState.AddModelError("Noidung", "Vui long nhap noi dung cau hoi");
                        //ModelState.Clear();
                    }
                    else
                    {
                        var cauhoi = new CAUHOI();
                        cauhoi.Noidung = c.Noidung;
                        cauhoi.Andanh = c.Andanh;
                        cauhoi.Thoigian = DateTime.Today;
                        cauhoi.Email = HttpContext.User.Identity.GetUserName();
                        cauhoi.MaTKAsp = HttpContext.User.Identity.GetUserId();
                        cauhoi.MaCD = c.MaCD;
                        model.CAUHOIs.Add(cauhoi);
                        model.SaveChanges();
                        ViewBag.Message = "Gui cau hoi thanh cong";
                        return View();
                    }
                }
            }
            //ViewBag.Chude = model.CHUDEs.OrderByDescending(x => x.MaCD).ToList();
            ViewBag.Action = "Index";
            ViewBag.Controller = "DatCauHoi";
            return View(c);
        }
    }
}