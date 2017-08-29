using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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