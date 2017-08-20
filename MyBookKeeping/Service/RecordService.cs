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

        public IQueryable<AccountBook> getAll( )
        {
            return _accountBookRepository.LookupAll( );
        }

        public void Save( )
        {
            _accountBookRepository.Commit( );
        }
    }
}