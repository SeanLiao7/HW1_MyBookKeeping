using System.Collections.Generic;
using MyBookKeeping.Models.ViewModels;

namespace MyBookKeeping.Service
{
    public interface IRecordService
    {
        IEnumerable<RecordViewModel> getAll( );
    }
}