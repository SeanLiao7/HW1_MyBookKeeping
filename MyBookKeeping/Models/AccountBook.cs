namespace MyBookKeeping.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table( "AccountBook" )]
    public partial class AccountBook
    {
        public int Amounttt { get; set; }
        public int Categoryyy { get; set; }
        public DateTime Dateee { get; set; }

        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public Guid Id { get; set; }

        [StringLength( 500 )]
        public string Remarkkk { get; set; }
    }
}