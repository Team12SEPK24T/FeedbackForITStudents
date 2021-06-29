﻿using FeedbackForITStudents.Models;
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
            
            var userIdentity = User.Identity.GetUserId();
            var allCauhoi = model.CAUHOIs.ToList();
            var today = DateTime.Now.Date;
            
            foreach (var item in allCauhoi)
            {
                //item.Thoigian = model.CAUHOIs. 
                //var thoiGian = model.CAUHOIs.Where(t => t.Thoigian == today).Count();
                var SLcauhoi = model.CAUHOIs.Where(h => h.MaTKAsp == userIdentity && h.Thoigian == today).Count();
                if (SLcauhoi >= 3)
                {
                    ViewBag.Message = "Ban da het luot dat cau hoi trong hom nay! Vi ban chi dat duoc toi da 3 cau hoi moi ngay.";
                    return View();
                    
                }
                else
                {
                    var cauhoi = new CAUHOI();
                    cauhoi.Noidung = c.Noidung;
                    cauhoi.Andanh = c.Andanh;
                    cauhoi.Thoigian = DateTime.Today;
                    cauhoi.Email = HttpContext.User.Identity.GetUserName();
                    cauhoi.MaTKAsp = HttpContext.User.Identity.GetUserId();
                    model.CAUHOIs.Add(cauhoi);
                    model.SaveChanges();
                    ViewBag.Message = "Gui cau hoi thanh cong";
                    return View(c);
                }
            }
            return View();
            //var cauhoi = new CAUHOI();
            //    cauhoi.Noidung = c.Noidung;
            //    cauhoi.Andanh = c.Andanh;
            //    cauhoi.Thoigian = DateTime.Now;
            //    cauhoi.Email = HttpContext.User.Identity.GetUserName();
            //    cauhoi.MaTKAsp = HttpContext.User.Identity.GetUserId();
            //    model.CAUHOIs.Add(cauhoi);
            //    model.SaveChanges();
            //    TempData["SuccessMessage"] = "Gửi câu hỏi thành công";
            //    return RedirectToAction("Index", "Home");

        }
    }
}