namespace MyBookKeeping.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table( "AccountBook" )]
    public partial class AccountBook
    {
        [Required]
        public int Amounttt { get; set; }

        [Required]
        public int Categoryyy { get; set; }

        [Required]
        public DateTime Dateee { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength( 500 )]
        public string Remarkkk { get; set; }
    }
}