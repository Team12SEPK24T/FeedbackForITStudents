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
            var account = model.TAIKHOANs.OrderByDescending(x => x.MaTK).ToList();
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
                account.Trangthai = a.Trangthai;
                account.Quyen = a.Quyen; 
                model.TAIKHOANs.Add(account);
                model.SaveChanges();
                return RedirectToAction("Index");
        }
           
    }
}