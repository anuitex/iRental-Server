using iRental.Domain.Identities;
using iRental.ViewModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Services
{
    public class AccountService
    {
        private readonly UserManager<UserIdentity> _userManager;

        public AccountService(UserManager<UserIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task RegistrateAsync(UserCreateRequest request)
        {

            //await _userManager.CreateAsync(user);
        }

        public async Task SignIn()
        {

        }
    }
}
