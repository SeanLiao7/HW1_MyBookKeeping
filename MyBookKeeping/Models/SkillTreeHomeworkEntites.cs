namespace MyBookKeeping.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SkillTreeHomeworkEntites : DbContext

    {
        public virtual DbSet<AccountBook> AccountBook { get; set; }

        public SkillTreeHomeworkEntites( )
                    : base( "name=SkillTreeHomeworkEntites" )
        {
        }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
        }
    }
}