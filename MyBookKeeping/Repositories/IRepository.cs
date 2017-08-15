using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace MyBookKeeping.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// unit of work
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// save change
        /// </summary>
        void commit( );

        /// <summary>
        /// 新增一個entity
        /// </summary>
        /// <param name="entity"></param>
        void create( T entity );

        /// <summary>
        /// 取得單一 entity
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T getSingle( Expression<Func<T, bool>> filter );

        /// <summary>
        /// Lookups all.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> lookupAll( );

        /// <summary>
        /// 搜尋
        /// </summary>
        /// <returns></returns>
        IQueryable<T> query( Expression<Func<T, bool>> filter );

        /// <summary>
        /// 刪除單一entity
        /// </summary>
        /// <param name="entity"></param>
        void remove( T entity );
    }
}