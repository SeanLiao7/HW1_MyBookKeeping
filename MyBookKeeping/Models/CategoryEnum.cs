using System.ComponentModel.DataAnnotations;

namespace MyBookKeeping.Models
{
    public enum CategoryEnum
    {
        [Display( Name = "支出" )]
        支出 = 0,

        [Display( Name = "收入" )]
        收入 = 1
    }
}