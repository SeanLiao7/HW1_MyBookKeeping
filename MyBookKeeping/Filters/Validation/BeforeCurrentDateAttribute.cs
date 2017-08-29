using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBookKeeping.Filters.Validation
{
    public sealed class BeforeCurrentDateAttribute : ValidationAttribute, IClientValidatable
    {
        public DateTime DateTime { get; set; } = DateTime.Now;

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules( ModelMetadata metadata, ControllerContext context )
        {
            ModelClientValidationRule rule = new ModelClientValidationRule
            {
                //ValidationType 的值一定要是小寫！
                ValidationType = "positivenumber",
                ErrorMessage = FormatErrorMessage( metadata.GetDisplayName( ) )
            };
            //ValidationParameters 一定要是小寫！
            rule.ValidationParameters[ "input" ] = convertDateTimeToJsFormat( );
            yield return rule;
        }

        public override bool IsValid( object value )
        {
            return value is DateTime date && date.Date <= DateTime.Date;
        }

        private static double convertDateTimeToJsFormat( )
        {
            return DateTime.UtcNow
                           .Subtract( new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc ) )
                           .TotalMilliseconds;
        }
    }
}