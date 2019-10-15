using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iRental.BusinessLogicLayer.Services;
using iRental.Validator.Validators.Account;
using iRental.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iRental.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<ActionResult> Registrate(UserCreateRequest request)
        {
            var validator = new CreateUserValidator();
            var resultValidation = validator.Validate(request);

            if (!resultValidation.IsValid)
            {

            }

            await _accountService.RegistrateAsync(request);
            return Ok();
        }
    }
}