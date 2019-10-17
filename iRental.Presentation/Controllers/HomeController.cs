using iRental.BusinessLogicLayer.Identity;
using iRental.BusinessLogicLayer.Services;
using iRental.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.Presentation.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly HomeService _homeService;
        private readonly ApplicationUserManager _applicationUserManager;

        public HomeController(HomeService homeService, ApplicationUserManager applicationUserManager)
        {
            _homeService = homeService;
            _applicationUserManager = applicationUserManager;
        }

        [HttpGet]
        public async Task<IEnumerable<AdvertListResponse>> GetAllForUserAsync()
        {
            string userId = _applicationUserManager.GetUserId(User);
            var response = await _homeService.GetAllForUserAsync(userId);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<AdvertsDetailsResponse> GetMoreByIdAsync([FromRoute] string id)
        {
            var userEntity = await _applicationUserManager.GetUserAsync(User);
            var response = await _homeService.GetMoreByIdAsync(id, userEntity);
            return response;
        }
    }
}