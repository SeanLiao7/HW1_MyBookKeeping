using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBookKeeping.Repositories
{
    public interface IDbContextFactory
    {
        DbContext DbContext { get; }
    }
}