using iRental.BusinessLogicLayer.Services;
using iRental.Validator.Validators.Account;
using iRental.ViewModel.RequestModels;
using iRental.ViewModel.ResponseModels;
using iRental.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iRental.Presentation.Controllers
{
    [Route("api/[controller]"), AllowAnonymous]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;


        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUpAsync([FromForm] UserCreateRequest request)
        {
            var validator = new CreateUserValidator();
            var resultValidation = validator.Validate(request);

            if (!resultValidation.IsValid)
            {
                return BadRequest(resultValidation.Errors);
            }

            var user = await _accountService.SignUpAsync(request);
            string codeAcceptEmail = await _accountService.CreateEmailConfirmCodeAsync(user);

            string urlCallback = Url.Action(
                        "ConfirmEmailAsync",
                        "Account",
                        new { userId = user.Id, code = codeAcceptEmail },
                        protocol: HttpContext.Request.Scheme);

            //todo: create sender and send code to email

            return Ok();
        }

        [HttpGet("email/confirm")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery]string userId, [FromQuery]string code)
        {
            await _accountService.ConfirmEmailAsync(userId, code);
            return Ok();
        }

        [HttpPost("sign-in")]
        public async Task<JwtTokensReponse> SignInAsync([FromBody] SignInRequest request)
        {
            var jwtTokens = await _accountService.SignInAsync(request);
            return jwtTokens;
        }

        [HttpPost("token/refresh")]
        public async Task<JwtTokensReponse> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var jwtTokens = await _accountService.RefreshTokensAsync(request);
            return jwtTokens;
        }

        [HttpGet("sign-out")]
        public async Task<IActionResult> SignOut()
        {
            await _accountService.SignOutAsync();
            return Ok();
        }
    }
}
