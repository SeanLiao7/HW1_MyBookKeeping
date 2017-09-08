using System;
using System.Linq;
using MyBookKeeping.Models;
using MyBookKeeping.Repositories;

namespace MyBookKeeping.Service
{
    public class AccountService
    {
        private readonly IRepository<SystemRole> _roleRepository;
        private readonly IRepository<SystemUser> _userRepository;

        public AccountService( IUnitOfWork unitOfWork )
        {
            _userRepository = new Repository<SystemUser>( unitOfWork );
            _roleRepository = new Repository<SystemRole>( unitOfWork );
        }

        private AccountService( )
        {
        }

        public void createNewUser( SystemUser user )
        {
            _userRepository.Create( user );
        }

        public IQueryable<SystemRole> getRoles( )
        {
            return _roleRepository.LookupAll( );
        }

        public SystemUser getUserById( Guid userId )
        {
            return _userRepository.GetSingle( x => x.UserId == userId );
        }

        public IQueryable<SystemUser> getUsers( )
        {
            return _userRepository.LookupAll( );
        }

        public void save( )
        {
            _userRepository.Commit( );
        }

        public void updateUser( SystemUser user )
        {
            _userRepository.Update( user );
        }
    }
}