﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWallet.Models
{
    public class TypesViewModel
    {
        [Key]
        public string Name { get; set; }
        public int? TypeId { get; set; }

    }
}