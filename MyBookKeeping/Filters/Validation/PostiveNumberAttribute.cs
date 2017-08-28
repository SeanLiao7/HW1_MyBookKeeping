using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookKeeping.Filters.Validation
{
    public class PostiveNumberAttribute : ValidationAttribute
    {
        public override bool IsValid( object value )
        {
            return value is decimal amount && amount % 1 == 0 && amount >= 1 && amount <= int.MaxValue;
        }
    }
}