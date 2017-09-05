using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBookKeeping.Models
{
    public class SystemRole
    {
        [DisplayName( "建立者" )]
        [Required]
        public Guid CreateBy { get; set; }

        [DisplayName( "建立時間" )]
        [Required]
        [DatabaseGenerated( DatabaseGeneratedOption.Computed )]
        public DateTime CreateOn { get; set; }

        [DisplayName( "是否使用" )]
        [Required]
        public bool IsEnable { get; set; }

        [DisplayName( "名稱" )]
        [Required]
        [StringLength( 50 )]
        [MinLength( 2, ErrorMessage = "長度不可小於 2" )]
        [MaxLength( 50, ErrorMessage = "長度不可超過 50" )]
        public string Name { get; set; }

        [DisplayName( "RoleId" )]
        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        [Required]
        public Guid RoleId { get; set; }

        [DisplayName( "排序" )]
        [Required]
        public int Sort { get; set; }

        public ICollection<SystemUser> SystemUsers { get; set; }

        [DisplayName( "更新者" )]
        public Guid? UpdateBy { get; set; }

        [DisplayName( "更新時間" )]
        public DateTime? UpdateOn { get; set; }

        public SystemRole( )
        {
            this.IsEnable = false;
            this.CreateBy = new Guid( );
            this.SystemUsers = new List<SystemUser>( );
        }
    }
}