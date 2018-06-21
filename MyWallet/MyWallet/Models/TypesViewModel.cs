﻿using System.ComponentModel.DataAnnotations;

namespace MyWallet.Models
{
    public class TypesViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TypeId { get; set; }

    }
}