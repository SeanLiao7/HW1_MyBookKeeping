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

        public IQueryable<AccountBook> getAll( )
        {
            return _accountBookRepository.LookupAll( );
        }
    }
}