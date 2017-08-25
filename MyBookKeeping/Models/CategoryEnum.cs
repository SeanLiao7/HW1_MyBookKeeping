using System.ComponentModel.DataAnnotations;

namespace MyBookKeeping.Models
{
    public enum CategoryEnum
    {
        [Display( Name = "支出" )]
        EXPEND = 0,

        [Display( Name = "收入" )]
        INCOME = 1
    }
}