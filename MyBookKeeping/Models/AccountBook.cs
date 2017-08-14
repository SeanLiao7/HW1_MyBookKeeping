namespace MyBookKeeping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table( "AccountBook" )]
    public partial class AccountBook
    {
        public int Amounttt { get; set; }
        public int Categoryyy { get; set; }
        public DateTime Dateee { get; set; }
        public Guid Id { get; set; }

        [Required]
        [StringLength( 500 )]
        public string Remarkkk { get; set; }
    }
}