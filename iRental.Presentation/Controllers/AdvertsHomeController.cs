using iRental.BusinessLogicLayer.Identity;
using iRental.BusinessLogicLayer.Services;
using iRental.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.Presentation.Controllers
{
    [Route("api/adverts/home"), Authorize]
    [ApiController]
    public class AdvertsHomeController : ControllerBase
    {
        private readonly AdvertsHomeService _homeService;
        private readonly ApplicationUserManager _applicationUserManager;

        public AdvertsHomeController(AdvertsHomeService homeService, ApplicationUserManager applicationUserManager)
        {
            _homeService = homeService;
            _applicationUserManager = applicationUserManager;
        }

        [HttpGet]
        public async Task<IEnumerable<AdvertListResponse>> GetAllAsync()
        {
            string userId = _applicationUserManager.GetUserId(User);
            var response = await _homeService.GetAllAsync(userId);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<AdvertsDetailsResponse> GetByIdAsync([FromRoute] string id)
        {
            var userEntity = await _applicationUserManager.GetUserAsync(User);
            var response = await _homeService.GetByIdAsync(id, userEntity);
            return response;
        }
    }
}