using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWallet.Models;

namespace MyWallet.Controllers
{
    public class HomeController : Controller
    {
        WalletDBEntities db = new WalletDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetBarChart()
        {
            var sixMonth = DateTime.Now.AddMonths(-6);
            MonthlyValuesViewModel mv = new MonthlyValuesViewModel();

            mv.Expenses = (from x in db.Activities
                           where x.Operations.TypeOperations.TypeId == 2 &
                           x.Date > sixMonth
                           group x by x.Date.Month into monthgroup
                           select monthgroup.Sum(x => x.Amount)).ToArray();

            mv.Revenues = (from x in db.Activities
                          where x.Operations.TypeOperations.TypeId == 1 &
                          x.Date > sixMonth
                          group x by x.Date.Month into monthgroup
                          select monthgroup.Sum(x => x.Amount)).ToArray();

            return PartialView(mv);
        }
       
    }
}