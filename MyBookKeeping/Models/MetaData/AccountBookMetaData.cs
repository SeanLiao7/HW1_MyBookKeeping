using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MyBookKeeping.Filters.Validation;
using ValidateSample.Filters.Validation;

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