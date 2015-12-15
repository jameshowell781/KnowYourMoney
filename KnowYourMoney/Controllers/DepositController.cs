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
    public class DepositController : Controller
    {
        private IST421JimTeam3Entities db = new IST421JimTeam3Entities();

        // GET: Deposit
        public ActionResult Index()
        {
            var tblDeposits = db.tblDeposits.Include(t => t.tblAccountInfo);
            return View(tblDeposits.ToList());
        }

        // GET: Deposit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDeposit tblDeposit = db.tblDeposits.Find(id);
            if (tblDeposit == null)
            {
                return HttpNotFound();
            }
            return View(tblDeposit);
        }

        // GET: Deposit/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn");
            return View();
        }

        // POST: Deposit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepositID,UserID,DepositAmount,Date")] tblDeposit tblDeposit)
        {
            if (ModelState.IsValid)
            {
                db.tblDeposits.Add(tblDeposit);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblDeposit.UserID);
            return View(tblDeposit);
        }

        // GET: Deposit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDeposit tblDeposit = db.tblDeposits.Find(id);
            if (tblDeposit == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblDeposit.UserID);
            return View(tblDeposit);
        }

        // POST: Deposit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepositID,UserID,DepositAmount,Date")] tblDeposit tblDeposit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDeposit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblDeposit.UserID);
            return View(tblDeposit);
        }

        // GET: Deposit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDeposit tblDeposit = db.tblDeposits.Find(id);
            if (tblDeposit == null)
            {
                return HttpNotFound();
            }
            return View(tblDeposit);
        }

        // POST: Deposit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDeposit tblDeposit = db.tblDeposits.Find(id);
            db.tblDeposits.Remove(tblDeposit);
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
