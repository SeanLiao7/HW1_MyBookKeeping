using System;
using System.ComponentModel.DataAnnotations;
using MyBookKeeping.Filters.Validation;
using ValidateSample.Filters.Validation;

namespace MyBookKeeping.Models.DataPostModels
{
    public class AccountRecord
    {
        [Required( ErrorMessage = "金額是必填項目" )]
        [RemotePlus( "AmountValidate", "Validate", "", ErrorMessage = "請輸入正整數 1 ~ 2147483647" )]
        [PostiveNumber]
        [Display( Name = "金額" )]
        [DisplayFormat( DataFormatString = "{0:N0}" )]
        [DataType( DataType.Text )]
        public decimal Amount { get; set; }

        [Required( ErrorMessage = "類別是必選項目" )]
        [Display( Name = "類別" )]
        public CategoryEnum Category { get; set; }

        [Required( ErrorMessage = "日期是必選項目" )]
        [Display( Name = "日期" )]
        [RemotePlus( "DateValidate", "Validate", "", ErrorMessage = "請選擇今日（含）以前的日期" )]
        [BeforeDate]
        [DisplayFormat( DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true )]
        public DateTime Date { get; set; }

        [StringLength( 100, ErrorMessage = "長度不可超過 100 字元" )]
        [Display( Name = "備註" )]
        public string Remark { get; set; }
    }
}