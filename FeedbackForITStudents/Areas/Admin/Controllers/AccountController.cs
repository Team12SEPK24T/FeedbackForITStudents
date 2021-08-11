using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackForITStudents.Models;
using System.Web.Mvc;
using WebCanteen.Areas.Admin.Middleware;

namespace FeedbackForITStudents.Areas.Admin.Controllers
{
    [LoginVerification]
    public class AccountController : Controller
    {
        SEP24Team12Entities model = new SEP24Team12Entities();
        // GET: Admin/Account
        public ActionResult Index()
        {
            var account = model.TAIKHOANs.ToList();
            return View(account);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Action = "Index";
            ViewBag.Controller = "Account";
            return View();
        }

        [HttpPost] 
        public ActionResult Create(TAIKHOAN a)
        {
            if (ModelState.IsValid)
            {
                var isEmailAlreadyExists = model.TAIKHOANs.Any(x => x.Email == a.Email);
                if (isEmailAlreadyExists)
                {
                    ModelState.AddModelError("Email", "User with this email already exists");
                }
                else
                {
                    var account = new TAIKHOAN();
                    account.Email = a.Email;
                    account.Hoten = a.Hoten;
                    account.Password = a.Password;
                    account.Trangthai = true;
                    account.Quyen = a.Quyen;
                    model.TAIKHOANs.Add(account);
                    model.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(a);
        }

        public ActionResult Edit(int id)
        {
            var account = model.TAIKHOANs.FirstOrDefault(f => f.MaTK == id);
            ViewBag.Action = "Index";
            ViewBag.Controller = "Account";
            return View(account);

        }

        [HttpPost]
        public ActionResult Edit(int id, TAIKHOAN editTaikhoan)
        {
            if (ModelState.IsValid)
            {
                var account = model.TAIKHOANs.FirstOrDefault(f => f.MaTK == id);
                account.Hoten = editTaikhoan.Hoten.Trim();
                account.Password = editTaikhoan.Password.Trim();
                model.SaveChanges();

                //ViewBag.Action = "Index";
                ViewBag.Message = "Cap nhat tai khoan thanh cong";
                return View(editTaikhoan);
            }
            return View(editTaikhoan);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int id, TAIKHOAN updateStatus)
        {
            if (Request["Inactive"] != null)
            {

                var taikhoan = model.TAIKHOANs.FirstOrDefault(f => f.MaTK == id);
                taikhoan.Trangthai = false;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (Request["Active"] != null)
            {
                var taikhoan = model.TAIKHOANs.FirstOrDefault(f => f.MaTK == id);
                taikhoan.Trangthai = true;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}