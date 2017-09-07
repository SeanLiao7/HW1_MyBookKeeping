using System;
using System.Linq;
using MyBookKeeping.Models;
using MyBookKeeping.Repositories;

namespace MyBookKeeping.Service
{
    public class AccountService
    {
        private readonly IRepository<SystemUser> _accountRepository;

        public AccountService( IUnitOfWork unitOfWork )
        {
            _accountRepository = new Repository<SystemUser>( unitOfWork );
        }

        private AccountService( )
        {
        }

        public void createNewUser( SystemUser user )
        {
            _accountRepository.Create( user );
        }

        public SystemUser getUserById( Guid userId )
        {
            return _accountRepository.GetSingle( x => x.UserId == userId );
        }

        public IQueryable<SystemUser> getUsers( )
        {
            return _accountRepository.LookupAll( );
        }

        public void save( )
        {
            _accountRepository.Commit( );
        }

        public void updateUser( SystemUser user )
        {
            _accountRepository.Update( user );
        }
    }
}