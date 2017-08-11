using System;
using System.Collections.Generic;
using System.Linq;
using MyBookKeeping.Models.ViewModels;

namespace MyBookKeeping.Service
{
    public class RecordService
    {
        public RecordService( )
        {
        }

        public IEnumerable<RecordViewModel> getAll( )
        {
            return Enumerable.Range( 0, 100 )
                .Select( x => new RecordViewModel
                {
                    Amount = ( x + 1 ) * 20,
                    Date = new DateTime( 2016, 10, 1 ) + new TimeSpan( x, 0, 0, 0, 0 ),
                    Category = x < 50 ? "支出" : "收入"
                }
            );
        }
    }
}