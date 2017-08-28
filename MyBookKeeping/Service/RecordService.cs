using System;
using System.Linq;
using MyBookKeeping.Models;
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

        public void createNewRecord( AccountBook record )
        {
            _accountBookRepository.Create( record );
        }

        public AccountBook getRecordById( Guid recordId )
        {
            return _accountBookRepository.GetSingle( x => x.Id == recordId );
        }

        public IQueryable<AccountBook> getRecords( )
        {
            return _accountBookRepository.LookupAll( );
        }

        public void save( )
        {
            _accountBookRepository.Commit( );
        }

        public void updateRecord( AccountBook record )
        {
            _accountBookRepository.Update( record );
        }
    }
}