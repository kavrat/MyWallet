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
        public string OpType { get; set; }

        
    }
}