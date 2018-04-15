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

        public JsonResult GetMonthly()
        {
            List<MonthlyValuesViewModel> values = new List<MonthlyValuesViewModel>();
            var sixMonth = DateTime.Now.AddMonths(-6);

            //var data = from x in db.Activities
            //           where x.Date > sixMonth
            //           group x by x.Date.Month into monthsgroup
            //           select new MonthlyValuesViewModel
            //           {
            //               Month = monthsgroup.Key.ToString(),
            //               MonthExpenses = monthsgroup.Where(x => x.Operations.TypeOperations.TypeId == 2).Sum(x => x.Amount),
            //               MonthRevenue = monthsgroup.Where(x => x.Operations.TypeOperations.TypeId == 1).Sum(x => x.Amount)

            //           };
            var data = db.Activities
                .Where(x => x.Date > sixMonth)
                .GroupBy(x => new { x.Date.Month, x.Date.Year });

            foreach (var item in data)
            {
                values.Add(new MonthlyValuesViewModel
                {
                    Month = String.Format("{0}/{1}", item.Key.Month, item.Key.Year),
                    MonthExpense = item.Where(x => x.Operations.TypeOperations.TypeId == 2).Sum(x => x.Amount),
                    MonthRevenue = item.Where(x => x.Operations.TypeOperations.TypeId == 1).Sum(x => x.Amount)
                });
            }

            return Json(values, JsonRequestBehavior.AllowGet);
        }
       
    }
}