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