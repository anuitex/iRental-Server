using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using iRental.Core;
using iRental.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iRental.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserManager _userManager;
        public AuthController(IUserManager userManager, ILogger logger)
        {
            _userManager = userManager ?? throw new ArgumentException(nameof(userManager));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult> SignInAsync(string email, string password)
        {
            try
            {
                await _userManager.SignInAsyn(email, password, true);
                return Ok("token data");
            }
            catch (ValidationException exception){
                return BadRequest(exception.Data);
            }
            catch (Exception exception)
            {
                await _logger.LogErrorAsync("GetAsync", exception);
                return StatusCode(500);
            }
        }


    }
}
