using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWallet.Controllers
{
    public class SettingsController : Controller
    {
        WalletDBEntities db = new WalletDBEntities();
        // GET: RevExSettings
        public ActionResult Index()
        {

            return View("RevExSettings");
        }

        // GET: RevExSettings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RevExSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RevExSettings/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RevExSettings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RevExSettings/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RevExSettings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RevExSettings/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
