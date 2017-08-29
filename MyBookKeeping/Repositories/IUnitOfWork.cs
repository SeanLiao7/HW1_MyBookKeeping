using System;
using System.Data.Entity;

namespace MyBookKeeping.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// context
        /// </summary>
        DbContext Context { get; }

        /// <summary>
        /// save change
        /// </summary>
        void Save( );
    }
}