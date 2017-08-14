using System.Data.Entity;
using MyBookKeeping.Models;

namespace MyBookKeeping.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; } = new SkillTreeHomeworkEntities( );

        public void Dispose( ) => Context.Dispose( );

        public void Save( ) => Context.SaveChanges( );
    }
}