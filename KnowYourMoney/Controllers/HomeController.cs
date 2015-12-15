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