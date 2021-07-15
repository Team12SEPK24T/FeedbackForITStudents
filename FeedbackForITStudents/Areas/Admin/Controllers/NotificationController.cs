using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FeedbackForITStudents.Models;

namespace FeedbackForITStudents.Areas.Admin.Controllers
{
    public class NotificationController : Controller
    {
        private SEP24Team12Entities db = new SEP24Team12Entities();

        // GET: Admin/Notification
        public ActionResult Index()
        {
            var thongbao = db.THONGBAOs.Include(t => t.CAUHOIDADUYET);
            return View(thongbao);
        }

        // GET: Admin/Notification/Details/5
        //        public ActionResult Details(string id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            THONGBAO tHONGBAO = db.THONGBAOs.Find(id);
        //            if (tHONGBAO == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(tHONGBAO);
        //        }

        //        // GET: Admin/Notification/Create
        //        public ActionResult Create()
        //        {
        //            return View();
        //        }

        //        // POST: Admin/Notification/Create
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Create([Bind(Include = "MaTB,thoigian")] THONGBAO tHONGBAO)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.THONGBAOs.Add(tHONGBAO);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }

        //            return View(tHONGBAO);
        //        }

        //        // GET: Admin/Notification/Edit/5
        //        public ActionResult Edit(string id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            THONGBAO tHONGBAO = db.THONGBAOs.Find(id);
        //            if (tHONGBAO == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(tHONGBAO);
        //        }

        //        // POST: Admin/Notification/Edit/5
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit([Bind(Include = "MaTB,thoigian")] THONGBAO tHONGBAO)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Entry(tHONGBAO).State = EntityState.Modified;
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            return View(tHONGBAO);
        //        }

        //        // GET: Admin/Notification/Delete/5
        //        public ActionResult Delete(string id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            THONGBAO tHONGBAO = db.THONGBAOs.Find(id);
        //            if (tHONGBAO == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(tHONGBAO);
        //        }

        //        // POST: Admin/Notification/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult DeleteConfirmed(string id)
        //        {
        //            THONGBAO tHONGBAO = db.THONGBAOs.Find(id);
        //            db.THONGBAOs.Remove(tHONGBAO);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing)
        //            {
        //                db.Dispose();
        //            }
        //            base.Dispose(disposing);
        //        }
    }
}
