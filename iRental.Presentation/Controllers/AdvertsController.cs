using iRental.BusinessLogicLayer.Identity;
using iRental.BusinessLogicLayer.Services;
using iRental.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.Presentation.Controllers
{
    [Route("api/adverts"), Authorize]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly AdvertService _advertService;
        private readonly ApplicationUserManager _applicationUserManager;

        public AdvertsController(ApplicationUserManager applicationUserManager, AdvertService advertService)
        {
            _applicationUserManager = applicationUserManager;
            _advertService = advertService;
        }

        [HttpPut]
        public async Task CreateAsync(AdvertCreateRequest requst)
        {
            string userId = _applicationUserManager.GetUserId(User);
            await _advertService.CreateAsync(requst, userId);
        }
    }
}