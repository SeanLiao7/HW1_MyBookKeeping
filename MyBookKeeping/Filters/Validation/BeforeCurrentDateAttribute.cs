using System;
using System.ComponentModel.DataAnnotations;

namespace MyBookKeeping.Filters.Validation
{
    public sealed class BeforeCurrentDateAttribute : ValidationAttribute
    {
        public override bool IsValid( object value )
        {
            return value is DateTime date && date.Date <= DateTime.Now.Date;
        }
    }
}