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

        public RecordService( IUnitOfWork unitOfWork )
        {
            _accountBookRepository = new Repository<AccountBook>( unitOfWork );
        }

        private RecordService( )
        {
        }

        public IEnumerable<RecordViewModel> getAll( )
        {
            return Mapper.Map<IQueryable<AccountBook>, IEnumerable<RecordViewModel>>
                ( _accountBookRepository.LookupAll( ) );
        }
    }
}