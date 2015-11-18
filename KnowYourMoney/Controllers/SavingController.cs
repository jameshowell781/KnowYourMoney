using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnowYourMoney.Models;

namespace KnowYourMoney.Controllers
{
    public class SavingController : Controller
    {
        private IST421JimTeam3Entities db = new IST421JimTeam3Entities();

        // GET: Saving
        public ActionResult Index()
        {
            var tblSavings = db.tblSavings.Include(t => t.tblAccountInfo);
            return View(tblSavings.ToList());
        }

        // GET: Saving Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSaving tblSaving = db.tblSavings.Find(id);
            if (tblSaving == null)
            {
                return HttpNotFound();
            }
            return View(tblSaving);
        }

        // GET: Saving Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn");
            return View();
        }

        // POST: Saving Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SavingsID,UserID,SavingsTotal")] tblSaving tblSaving)
        {
            if (ModelState.IsValid)
            {
                db.tblSavings.Add(tblSaving);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblSaving.UserID);
            return View(tblSaving);
        }

        // GET: Saving Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSaving tblSaving = db.tblSavings.Find(id);
            if (tblSaving == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblSaving.UserID);
            return View(tblSaving);
        }

        // POST: Saving Edit
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SavingsID,UserID,SavingsTotal")] tblSaving tblSaving)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSaving).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblSaving.UserID);
            return View(tblSaving);
        }

        // GET: Saving Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSaving tblSaving = db.tblSavings.Find(id);
            if (tblSaving == null)
            {
                return HttpNotFound();
            }
            return View(tblSaving);
        }

        // POST: Saving Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSaving tblSaving = db.tblSavings.Find(id);
            db.tblSavings.Remove(tblSaving);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
