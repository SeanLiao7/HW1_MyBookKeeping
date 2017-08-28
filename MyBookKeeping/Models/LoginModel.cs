using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace MyBookKeeping.Models
{
    public class LoginModel
    {
        [Required]
        [DisplayName( "帳號" )]
        public string Account { get; set; }

        [Required]
        [DataType( DataType.Password )]
        [DisplayName( "密碼" )]
        public string PassWord { get; set; }
    }
}