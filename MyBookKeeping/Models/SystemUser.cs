using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBookKeeping.Models
{
    public class SystemUser
    {
        [DisplayName( "帳號" )]
        [Required]
        [StringLength( 50 )]
        [MinLength( 5, ErrorMessage = "長度不可小於 5" )]
        [MaxLength( 50, ErrorMessage = "長度不可超過 50" )]
        public string Account { get; set; }

        [DisplayName( "建立者" )]
        [Required]
        public Guid CreateBy { get; set; }

        [DisplayName( "建立時間" )]
        [Required]
        [DatabaseGenerated( DatabaseGeneratedOption.Computed )]
        public DateTime CreateOn { get; set; }

        [DisplayName( "Email" )]
        [Required]
        [StringLength( 200 )]
        [MinLength( 2, ErrorMessage = "長度不可小於 2" )]
        [MaxLength( 200, ErrorMessage = "長度不可超過 200" )]
        [DataType( DataType.EmailAddress )]
        public string Email { get; set; }

        [DisplayName( "是否使用" )]
        [Required]
        public bool IsEnable { get; set; }

        [DisplayName( "名稱" )]
        [Required]
        [StringLength( 50 )]
        [MinLength( 2, ErrorMessage = "長度不可小於 2" )]
        [MaxLength( 50, ErrorMessage = "長度不可超過 50" )]
        public string Name { get; set; }

        [DisplayName( "密碼" )]
        [Required]
        [StringLength( 200 )]
        [MinLength( 5, ErrorMessage = "長度不可小於 5" )]
        [MaxLength( 200, ErrorMessage = "長度不可超過 200" )]
        public string Password { get; set; }

        [DisplayName( "系統角色" )]
        public ICollection<SystemRole> SystemRoles { get; set; }

        [DisplayName( "更新者" )]
        public Guid? UpdateBy { get; set; }

        [DisplayName( "更新時間" )]
        public DateTime? UpdateOn { get; set; }

        [DisplayName( "UserId" )]
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        [Required]
        public Guid UserId { get; set; }

        public SystemUser( )
        {
            this.IsEnable = false;
            this.CreateBy = new Guid( );
            this.SystemRoles = new List<SystemRole>( );
        }
    }
}