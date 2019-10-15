using iRental.BusinessLogicLayer.Mappers.User;
using iRental.Domain.Identity;
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
        private readonly SignInManager<UserIdentity> _signInManager;

        public AccountService(UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task RegistrateAsync(UserCreateRequest request)
        {
            var userEntity = UserCreateMapper.Map(request);
            await _userManager.CreateAsync(userEntity);
        }

        public async Task SignIn()
        {

        }
    }
}
