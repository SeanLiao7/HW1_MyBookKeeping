using System;
using System.Collections.Generic;
using System.Linq;
using MyBookKeeping.Models.ViewModels;
using MyBookKeeping.Models;
using MyBookKeeping.Repositories;
using AutoMapper;

namespace MyBookKeeping.Service
{
    public class RecordService
    {
        private readonly IRepository<AccountBook> _accountBookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecordService( IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
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