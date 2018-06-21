using MyWallet.Models;
using System.Linq;
using System.Web.Mvc;

namespace MyWallet.Controllers
{
    public class TableController : Controller
    {
        WalletDBEntities db = new WalletDBEntities();
        // GET: Table
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Filter()
        {


            var data = from a in db.Activities
                   select new TableViewModel
                   {
                       Id = a.Id,
                       Date = a.Date,
                       Description = a.Description,
                       NameOp = a.Operations.NameOp,
                       OpType = a.Operations.TypeOperations.Type,
                       Amount = a.Amount

                   };

            return PartialView(data);
        }

        //// GET: Table/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Table/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Table/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Table/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Table/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Table/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Table/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
