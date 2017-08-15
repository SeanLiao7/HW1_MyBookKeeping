using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyBookKeeping.Models;
using MyBookKeeping.Models.ViewModels;
using MyBookKeeping.Repositories;

namespace MyBookKeeping.Service
{
    public class RecordService
    {
        private readonly IRepository<AccountBook> _accountBookRepository;

        public RecordService( IRepository<AccountBook> accountBookRepository )
        {
            _accountBookRepository = accountBookRepository;
        }

        public IEnumerable<RecordViewModel> getAll( )
        {
            return Mapper.Map<IQueryable<AccountBook>, IEnumerable<RecordViewModel>>
                ( _accountBookRepository.lookupAll( ) );
        }
    }
}