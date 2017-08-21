using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookKeeping.Models
{
    public class AccountRecord
    {
        [Required]
        [Display( Name = "金額" )]
        public int Amount { get; set; }

        [Required]
        [Display( Name = "類別" )]
        public CategoryEnum Category { get; set; }

        [Required]
        [Display( Name = "日期" )]
        public DateTime Date { get; set; }

        [Required]
        [StringLength( 100 )]
        [Display( Name = "備註" )]
        public string Remark { get; set; }
    }
}