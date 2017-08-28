using System.ComponentModel.DataAnnotations;

namespace MyBookKeeping.Filters.Validation
{
    public sealed class PostiveNumberAttribute : ValidationAttribute
    {
        public override bool IsValid( object value )
        {
            return value is decimal amount && amount % 1 == 0 && amount >= 1 && amount <= int.MaxValue;
        }
    }
}