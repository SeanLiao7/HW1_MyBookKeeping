using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBookKeeping.Filters.Validation
{
    public class BeforeDateAttribute : ValidationAttribute
    {
        public override bool IsValid( object value )
        {
            return value is DateTime date && date.Date <= DateTime.Now.Date;
        }
    }
}