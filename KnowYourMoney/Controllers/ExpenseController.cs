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
    public class ExpenseController : Controller
    {
        private IST421JimTeam3Entities db = new IST421JimTeam3Entities();

        // GET: Expense
        public ActionResult Index()
        {
            var tblExpenses = db.tblExpenses.Include(t => t.tblAccountInfo).Include(t => t.tblTransaction);
            return View(tblExpenses.ToList());
        }

        // GET: Expense/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExpens tblExpens = db.tblExpenses.Find(id);
            if (tblExpens == null)
            {
                return HttpNotFound();
            }
            return View(tblExpens);
        }

        // GET: Expense/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn");
            ViewBag.TransactionID = new SelectList(db.tblTransactions, "TransactionID", "Merchant");
            return View();
        }

        // POST: Expense/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseID,UserID,TransactionID,Date,ExpenseTotal")] tblExpens tblExpens)
        {
            if (ModelState.IsValid)
            {
                db.tblExpenses.Add(tblExpens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblExpens.UserID);
            ViewBag.TransactionID = new SelectList(db.tblTransactions, "TransactionID", "Merchant", tblExpens.TransactionID);
            return View(tblExpens);
        }

        // GET: Expense/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExpens tblExpens = db.tblExpenses.Find(id);
            if (tblExpens == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblExpens.UserID);
            ViewBag.TransactionID = new SelectList(db.tblTransactions, "TransactionID", "Merchant", tblExpens.TransactionID);
            return View(tblExpens);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseID,UserID,TransactionID,Date,ExpenseTotal")] tblExpens tblExpens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblExpens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.tblAccountInfoes, "UserID", "UserLogIn", tblExpens.UserID);
            ViewBag.TransactionID = new SelectList(db.tblTransactions, "TransactionID", "Merchant", tblExpens.TransactionID);
            return View(tblExpens);
        }

        // GET: Expense/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExpens tblExpens = db.tblExpenses.Find(id);
            if (tblExpens == null)
            {
                return HttpNotFound();
            }
            return View(tblExpens);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblExpens tblExpens = db.tblExpenses.Find(id);
            db.tblExpenses.Remove(tblExpens);
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
