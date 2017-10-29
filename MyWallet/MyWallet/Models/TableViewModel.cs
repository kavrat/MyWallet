using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyWallet.Models
{
    public class TableViewModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string NameOp { get; set; }
        public int TypeId { get; set; }
        public string OpType { get; set; }
        public IEnumerable<SelectListItem> NameOpList { get; set; }
        public int OpId { get; set; }
        public IEnumerable<TableViewModel> tableCollection;

        public TableViewModel() { }
        public TableViewModel(int? TypeId)
        {
            using (var db = new WalletDBEntities())
            {
                tableCollection = (from a in db.Activities
                            join o in db.Operations
                            on a.OpId equals o.OpId

                            join t in db.TypeOperations
                            on o.TypeId equals t.TypeId
                            select new
                            {
                                id = a.Id,
                                date = a.Date,
                                nameOp = o.NameOp,
                                optype = t.Type,
                                amount = a.Amount,
                                description = a.Description,
                                typeid = t.TypeId
                            }).ToList()
                            .Select(x => new TableViewModel()
                            {
                                Id = x.id,
                                Date = x.date,
                                NameOp = x.nameOp,
                                OpType = x.optype,
                                Amount = x.amount,
                                Description = x.description,
                                TypeId = x.typeid
                            });
                if (TypeId != null)
                {
                    tableCollection = tableCollection.Where(p => p.TypeId == TypeId);
                }

            }
        }
    }
}