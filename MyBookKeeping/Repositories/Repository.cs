using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        private Repository( )
        {
        }

        public void Commit( ) => UnitOfWork.Save( );

        public void Create( T entity ) => DbSet.Add( entity );

        public T GetSingle( Expression<Func<T, bool>> filter ) => DbSet.SingleOrDefault( filter );

        public IQueryable<T> LookupAll( ) => DbSet;

        public IQueryable<T> Query( Expression<Func<T, bool>> filter ) => DbSet.Where( filter );

        public void Remove( T entity ) => DbSet.Remove( entity );

        public void Update( T entity ) => UnitOfWork.Context.Entry( entity ).State = EntityState.Modified;
    }
}