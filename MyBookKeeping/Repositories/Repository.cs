using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyBookKeeping.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; }
        private DbSet<T> DbSet { get; }

        public Repository( IUnitOfWork unitOfWork )
        {
            UnitOfWork = unitOfWork;
            DbSet = unitOfWork.Context.Set<T>( );
        }

        public void commit( ) => UnitOfWork.save( );

        public void create( T entity ) => DbSet.Add( entity );

        public T getSingle( Expression<Func<T, bool>> filter ) => DbSet.SingleOrDefault( filter );

        public IQueryable<T> lookupAll( ) => DbSet;

        public IQueryable<T> query( Expression<Func<T, bool>> filter ) => DbSet.Where( filter );

        public void remove( T entity ) => DbSet.Remove( entity );
    }
}