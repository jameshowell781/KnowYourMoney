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
    public class WithdrawController : Controller
    {
        private IST421JimTeam3Entities db = new IST421JimTeam3Entities();

        // GET: Withdraw
        public ActionResult Index()
        {
            var tblWithdraws = db.tblWithdraws.Include(t => t.tblAccountInfo).Where(x => x.UserID == 6);
            decimal? total_withdraw = 0;
            foreach (tblWithdraw withdrawn in tblWithdraws)
                total_withdraw += withdrawn.WithdrawAmount;
            string currencyValue = total_withdraw.Value.ToString("0.00");
            ViewData["withdraw_total"] = currencyValue;
            return View(tblWithdraws.ToList());
        }

        // GET: Withdraw/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWithdraw tblWithdraw = db.tblWithdraws.Find(id);
            if (tblWithdraw == null)
            {
                return HttpNotFound();
            }
            return View(tblWithdraw);
        }

        // GET: Withdraw/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn");
            return View();
        }

        // POST: Withdraw/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WithdrawID,UserID,WithdrawAmount,Date")] tblWithdraw tblWithdraw)
        {
            if (ModelState.IsValid)
            {
                db.tblWithdraws.Add(tblWithdraw);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblWithdraw.UserID);
            return View(tblWithdraw);
        }

        // GET: Withdraw/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWithdraw tblWithdraw = db.tblWithdraws.Find(id);
            if (tblWithdraw == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblWithdraw.UserID);
            return View(tblWithdraw);
        }

        // POST: Withdraw/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WithdrawID,UserID,WithdrawAmount,Date")] tblWithdraw tblWithdraw)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblWithdraw).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblWithdraw.UserID);
            return View(tblWithdraw);
        }

        // GET: Withdraw/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWithdraw tblWithdraw = db.tblWithdraws.Find(id);
            if (tblWithdraw == null)
            {
                return HttpNotFound();
            }
            return View(tblWithdraw);
        }

        // POST: Withdraw/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblWithdraw tblWithdraw = db.tblWithdraws.Find(id);
            db.tblWithdraws.Remove(tblWithdraw);
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
