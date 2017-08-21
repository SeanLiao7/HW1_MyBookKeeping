namespace MyBookKeeping.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table( "AccountBook" )]
    public partial class AccountBook
    {
        [Required]
        [Display( Name = "金額" )]
        public int Amounttt { get; set; }

        [Required]
        [Display( Name = "類別" )]
        public int Categoryyy { get; set; }

        [Required]
        [Display( Name = "日期" )]
        public DateTime Dateee { get; set; }

        public Guid Id { get; set; }

        [Required]
        [StringLength( 500 )]
        [Display( Name = "備註" )]
        public string Remarkkk { get; set; }
    }
}