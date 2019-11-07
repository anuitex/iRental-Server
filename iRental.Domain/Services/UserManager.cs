using iRental.Core;
using iRental.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace iRental.Domain.Services
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;
        private IEmailService _emailService;

        public UserManager(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task SignInAsyn(string email, string password, bool isLocked = true)
        {
            throw new NotImplementedException();
        }

        public async Task SignUpAsyn()
        {
            throw new NotImplementedException();
        }

        public async Task LogOut()
        {
            throw new NotImplementedException();
        }
    }
}