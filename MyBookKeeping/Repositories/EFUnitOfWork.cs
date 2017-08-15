using System.Data.Entity;
using MyBookKeeping.Models;

namespace MyBookKeeping.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly IDbContextFactory _dbContextFactory;

        public DbContext Context => _dbContextFactory.DbContext;

        public EFUnitOfWork( IDbContextFactory dbContextFactory )
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Dispose( ) => Context.Dispose( );

        public void save( ) => Context.SaveChanges( );
    }
}