using System;
using System.Data.Entity;

namespace MyBookKeeping.Repositories
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly string _connectionString;

        private DbContext _dbContext;

        public DbContext DbContext
        {
            get
            {
                if ( _dbContext == null )
                {
                    var t = typeof( DbContext );
                    _dbContext = ( DbContext ) Activator.CreateInstance( t, _connectionString );
                }
                return _dbContext;
            }
        }

        public DbContextFactory( string connectionString )
        {
            _connectionString = connectionString;
        }
    }
}