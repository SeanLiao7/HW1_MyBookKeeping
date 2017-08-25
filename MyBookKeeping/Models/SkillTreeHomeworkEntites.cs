namespace MyBookKeeping.Models
{
    using System.Data.Entity;

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