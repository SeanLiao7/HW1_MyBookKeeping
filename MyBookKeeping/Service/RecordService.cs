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
        private readonly IUnitOfWork _unitOfWork;

        public RecordService( IUnitOfWork unitOfWork, IRepository<AccountBook> accountBookRepository )
        {
            _accountBookRepository = accountBookRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RecordViewModel> getAll( )
        {
            return Mapper.Map<IQueryable<AccountBook>, IEnumerable<RecordViewModel>>
                ( _accountBookRepository.lookupAll( ) );
        }
    }
}