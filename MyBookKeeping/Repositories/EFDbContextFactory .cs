using System;
using System.Data.Entity;
using MyBookKeeping.Models;

namespace MyBookKeeping.Repositories
{
    public class EFDbContextFactory : IDbContextFactory
    {
        private DbContext _dbContext;

        public DbContext DbContext
        {
            get
            {
                if ( _dbContext == null )
                    _dbContext = new SkillTreeHomeworkEntites( );
                return _dbContext;
            }
        }
    }
}