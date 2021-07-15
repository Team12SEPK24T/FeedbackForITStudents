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
            //ValidateModel(model);
            //ValidateAccount(editTaikhoan);
            //if (ModelState.IsValid)
           // {
                var account = model.TAIKHOANs.FirstOrDefault(f => f.MaTK == id);
                account.Hoten = editTaikhoan.Hoten.Trim();
                account.Password = editTaikhoan.Password.Trim();
                account.Trangthai = editTaikhoan.Trangthai; ;
                //model.Entry(account).State = System.Data.Entity.EntityState.Modified;
                model.SaveChanges();

            //}
            ViewBag.Action = "Index";
            ViewBag.Controller = "Account";
            return RedirectToAction("Index", "Account");
            //return View(editTaikhoan);
            //return View();
        }
        private void ValidateAccount(TAIKHOAN model)
        {
            if (model.Hoten == null)
            {
                ModelState.AddModelError("Hoten", "Vui lòng nhập tên thương hiệu.");
            }
            else if (String.IsNullOrWhiteSpace(model.Hoten))
            {
                ModelState.AddModelError("Hoten", "Kí tự không hợp lệ.");
            }
            if (model.Password == null)
            {
                ModelState.AddModelError("Password", "Vui lòng nhập tên thương hiệu.");
            }
            else if (String.IsNullOrWhiteSpace(model.Password))
            {
                ModelState.AddModelError("Password", "Kí tự không hợp lệ.");
            }
        }

    }
}