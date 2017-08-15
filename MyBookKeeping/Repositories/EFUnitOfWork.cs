using System.Data.Entity;
using MyBookKeeping.Models;

namespace MyBookKeeping.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public DbContext Context
        {
            get
            {
                if ( _context == null )
                    _context = new SkillTreeHomeworkEntites( );
                return _context;
            }
        }

        public void Dispose( ) => Context.Dispose( );

        public void save( ) => Context.SaveChanges( );
    }
}