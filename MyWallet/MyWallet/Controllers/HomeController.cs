﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            ViewBag.Revenue = db.Activities.Where(x => x.Operations.TypeId == 1).Select(y => y.Amount).Sum();
            ViewBag.Expense = db.Activities.Where(x => x.Operations.TypeId == 2).Select(y => y.Amount).Sum();
            return View();
        }

        public JsonResult GetMonthly()
        {
            List<MonthlyValuesViewModel> values = new List<MonthlyValuesViewModel>();
            var sixMonth = DateTime.Now.AddMonths(-6);

            var data = db.Activities
                .Where(x => x.Date > sixMonth)
                .GroupBy(x => new { x.Date.Month, x.Date.Year }).OrderBy(x => x.Key.Year);

            foreach (var item in data)
            {
                values.Add(new MonthlyValuesViewModel
                {
                    Month = string.Format("{0}/{1}", item.Key.Month, item.Key.Year),
                    MonthExpense = item.Where(x => x.Operations.TypeOperations.TypeId == 2).Sum(x => x.Amount),
                    MonthRevenue = item.Where(x => x.Operations.TypeOperations.TypeId == 1).Sum(x => x.Amount)
                });
            }
            //GetWeeklyExpanses();
            return Json(values, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWeeklyExpanses()
        {
            List<WeeklyExpensesViewModel> weeklyExpenses = new List<WeeklyExpensesViewModel>();
            var lastWeek = DateTime.Now.AddDays(-7);
            var data = db.Activities
                .Where(x => x.Date > lastWeek)
                .Where(x => x.Operations.TypeOperations.TypeId == 2)
                .GroupBy(x => x.Operations.NameOp)
                .Select(x => new WeeklyExpensesViewModel
                {
                    Name = x.Key,
                    Value = x.Sum(y => y.Amount)
                });

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //!!!!!
        [HttpPost]
        public ActionResult AddRevenue(RevenueViewModel revenue)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Activities.Add(new Activities
                    {
                        Amount = revenue.Amount,
                        Description = revenue.Description,
                        Date = DateTime.Now,
                        OpId = revenue.OpId
                    });
                    db.SaveChanges();

                }
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}