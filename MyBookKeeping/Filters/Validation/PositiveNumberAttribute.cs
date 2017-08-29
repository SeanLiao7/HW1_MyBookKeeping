using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBookKeeping.Filters.Validation
{
    public sealed class PositiveNumberAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules( ModelMetadata metadata, ControllerContext context )
        {
            ModelClientValidationRule rule = new ModelClientValidationRule
            {
                //ValidationType 的值一定要是小寫！
                ValidationType = "positivenumber",
                ErrorMessage = FormatErrorMessage( metadata.GetDisplayName( ) )
            };
            //ValidationParameters 一定要是小寫！
            rule.ValidationParameters[ "input" ] = int.MaxValue;
            yield return rule;
        }

        public override bool IsValid( object value )
        {
            return value is decimal amount && amount % 1 == 0 && amount >= 1 && amount <= int.MaxValue;
        }
    }
}