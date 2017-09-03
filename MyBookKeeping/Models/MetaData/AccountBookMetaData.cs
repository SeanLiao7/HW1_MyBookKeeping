using System;
using System.ComponentModel.DataAnnotations;

namespace MyBookKeeping.Models
{
    [MetadataType( typeof( AccountBookMetaData ) )]
    public partial class AccountBook
    {
        public class AccountBookMetaData
        {
            public int Amounttt { get; set; }
            public int Categoryyy { get; set; }
            public DateTime Dateee { get; set; }
            public Guid Id { get; set; }
            public string Remarkkk { get; set; }
        }
    }
}