using System.Linq;
using System.Web.Mvc;
using MyWallet.Models;

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

        public PartialViewResult TypeList(int type)
        {
            var data = from d in db.Operations
                       where d.TypeId == type
                       select new TypesViewModel
                       {
                           Id = d.OpId,
                           Name = d.NameOp,
                           TypeId = d.TypeId
                       };
            return PartialView("TypeList", data);
        }


        // POST: RevExSettings/Add
        [HttpPost]
        public ActionResult Add(TypesViewModel t)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Operations.Add(new Operations
                    {
                        NameOp = t.Name,
                        TypeId = t.TypeId,
                        TypeOperations = db.TypeOperations.Single(x => x.TypeId == t.TypeId)
                    });
                    db.SaveChanges();
                }
                return new HttpStatusCodeResult(201); //need to be changed
            }
            catch
            {
                return new HttpStatusCodeResult(501); //need to be changed
            }
            
        }


        // POST: RevExSettings/Edit/5
        [HttpPost]
        public ActionResult Edit(TypesViewModel t)
        {
            Operations op = new Operations
            {
                NameOp = t.Name,
                OpId = t.Id,
                TypeId = t.TypeId
            };
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(op).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return new HttpStatusCodeResult(201); //need to be changed
            }
            catch
            {
                return new HttpStatusCodeResult(501); //need to be changed
            }
        }

        // POST: RevExSettings/Delete/5
        [HttpPost]
        public ActionResult Delete(int index)
        {
            Operations op = db.Operations.Find(index);
            
            try
            {
                if (op != null)
                {
                    db.Operations.Remove(op);
                    db.SaveChanges();
                }

                return new HttpStatusCodeResult(201); //need to be changed
            }
            catch
            {
                return new HttpStatusCodeResult(501); //need to be changed
            }
        }
    }
}
