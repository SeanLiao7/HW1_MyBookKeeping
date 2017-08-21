namespace MyBookKeeping.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table( "AccountBook" )]
    public partial class AccountBook
    {
        [Required]
        [Display( Name = "���B" )]
        public int Amounttt { get; set; }

        [Required]
        [Display( Name = "���O" )]
        public int Categoryyy { get; set; }

        [Required]
        [Display( Name = "���" )]
        public DateTime Dateee { get; set; }

        public Guid Id { get; set; }

        [Required]
        [StringLength( 500 )]
        [Display( Name = "�Ƶ�" )]
        public string Remarkkk { get; set; }
    }
}