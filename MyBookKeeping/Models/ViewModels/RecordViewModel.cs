using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBookKeeping.Models.ViewModels
{
    public class RecordViewModel
    {
        [Display( Name = "金額" )]
        [DisplayFormat( DataFormatString = "{0:N0}" )]
        public decimal Amount { get; set; }

        [Display( Name = "類別" )]
        public CategoryEnum Category { get; set; }

        [Display( Name = "日期" )]
        [DisplayFormat( DataFormatString = "{0:yyyy-MM-dd}" )]
        public DateTime Date { get; set; }

        [HiddenInput( DisplayValue = false )]
        public Guid RecordId { get; set; }
    }
}