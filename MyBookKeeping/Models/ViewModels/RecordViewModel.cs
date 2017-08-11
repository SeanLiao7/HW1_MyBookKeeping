﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MyBookKeeping.Models.ViewModels
{
    public class RecordViewModel
    {
        [Required]
        [Display( Name = "金額" )]
        [DisplayFormat( DataFormatString = "{0:#,0}" )]
        public decimal Amount { get; set; }

        [Required]
        [Display( Name = "類別" )]
        public string Category { get; set; }

        [Required]
        [Display( Name = "日期" )]
        [DisplayFormat( DataFormatString = "{0:yyyy-MM-dd}" )]
        public DateTime Date { get; set; }
    }
}