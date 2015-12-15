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
    public class HomeController : Controller
    {
        private IST421JimTeam3Entities db = new IST421JimTeam3Entities();
        
        public ActionResult Index()
        {
            var accounts = db.tblAccountInfoes;
            var tblSavings = db.tblSavings.Include(t => t.tblAccountInfo).Where(x => x.UserID == 6);
            var tblDeposits = db.tblDeposits.Include(t => t.tblAccountInfo).Where(x => x.UserID == 6);
            var tblWithdraws = db.tblWithdraws.Include(t => t.tblAccountInfo).Where(x => x.UserID == 6);
            var tblExpenses = db.tblExpenses.Include(t => t.tblAccountInfo).Include(t => t.tblTransaction).Where(x => x.UserID == 6);
            var deposits = db.tblDeposits.Where(x => x.UserID == 6).ToList();
            var expenses = db.tblExpenses.Where(x => x.UserID == 6).ToList();
            var withdraws = db.tblWithdraws.Where(x => x.UserID == 6).ToList();
            
            ViewData["deposit_count"] = deposits.Count();
            ViewData["expense_count"] = expenses.Count();
            ViewData["withdraw_count"] = withdraws.Count();
            
            decimal? total_deposit = 0;
            foreach (tblDeposit deposited in tblDeposits)
                total_deposit += deposited.DepositAmount;
            string currencydeposit = total_deposit.Value.ToString("0.00");
            decimal? total_expense = 0;
            foreach (tblExpens cost in tblExpenses)
                total_expense += cost.ExpenseTotal;
            string currencyexpense = total_expense.Value.ToString("0.00");
            decimal? total_withdraw = 0;
            foreach (tblWithdraw withdrawn in tblWithdraws)
                total_withdraw += withdrawn.WithdrawAmount;
            string currencywithdraw = total_withdraw.Value.ToString("0.00");
            decimal? total_saving = total_deposit - total_withdraw - total_expense;
            string currencysaving = total_saving.Value.ToString("0.00");
            ViewData["saving_total"] = currencysaving;
            ViewData["deposit_total"] = currencydeposit;
            ViewData["withdraw_total"] = currencywithdraw;
            ViewData["expense_total"] = currencyexpense;
            return View(accounts);
        }

        private ActionResult View(Func<IEnumerable<tblAccountInfo>, List<tblAccountInfo>> func)
        {
            throw new NotImplementedException();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult makechart()
        {
            return View();
        }
        public ActionResult makechart2()
        {
            return View();
        }
    }

}