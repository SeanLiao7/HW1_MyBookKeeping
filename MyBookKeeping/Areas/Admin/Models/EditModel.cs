using System;

namespace MyBookKeeping.Areas.Admin.Models
{
    public class EditModel
    {
        public int Amount { get; set; }
        public int Category { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
    }
}