﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackForITStudents.Models;
using System.Web.Mvc;

namespace FeedbackForITStudents.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        FBFORITSTUDENTSEntities model = new FBFORITSTUDENTSEntities();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = model.Taikhoans.FirstOrDefault(u => u.Email.Equals(email));
            if (user != null)
            {
                if (user.matkhau.Equals(password))
                {
                    Session["user-fullname"] = user.hoten;
                    Session["user-id"] = user.Ma_tai_khoan;
                    Session["user-role"] = user.Quyen;
                    return RedirectToAction("Index", "AdminHome");
                }
                else
                {
                    Session["password-incorrect"] = true;
                    return View();
                }
            }
            Session["user-not-found"] = true;
            return View();
        }
        public ActionResult Logout()
        {
            Session["user-fullname"] = null;
            Session["user-id"] = null;
            return RedirectToAction("Login");
        }
    }
}