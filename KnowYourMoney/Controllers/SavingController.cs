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
            var tblSavings = db.tblSavings.Include(t => t.tblAccountInfo).Where(x => x.UserID == 6);
            var tblDeposits = db.tblDeposits.Include(t => t.tblAccountInfo).Where(x => x.UserID == 6);
            var tblWithdraws = db.tblWithdraws.Include(t => t.tblAccountInfo).Where(x => x.UserID == 6);
            var tblExpenses = db.tblExpenses.Include(t => t.tblAccountInfo).Include(t => t.tblTransaction).Where(x => x.UserID == 6);
            decimal? total_deposit = 0;
            foreach (tblDeposit deposited in tblDeposits)
                total_deposit += deposited.DepositAmount;
            //string currencydeposit = total_deposit.Value.ToString("0.00");
            decimal? total_expense = 0;
            foreach (tblExpens cost in tblExpenses)
                total_expense += cost.ExpenseTotal;
            //string currencyexpense = total_expense.Value.ToString("0.00");
            decimal? total_withdraw = 0;
            foreach (tblWithdraw withdrawn in tblWithdraws)
                total_withdraw += withdrawn.WithdrawAmount;
            //string currencywithdraw = total_withdraw.Value.ToString("0.00");
            decimal? total_saving = total_deposit - total_withdraw - total_expense;
            string currencysaving = total_saving.Value.ToString("0.00");
            ViewData["saving_total"] = currencysaving;
            
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
        //public ActionResult SavingsChart()
        //{
           
        //}
    }
}
