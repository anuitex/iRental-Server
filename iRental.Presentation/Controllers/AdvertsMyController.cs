using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iRental.BusinessLogicLayer.Identity;
using iRental.BusinessLogicLayer.Services;
using iRental.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iRental.Presentation.Controllers
{
    [Route("api/adverts/my")]
    [ApiController]
    public class AdvertsMyController : ControllerBase
    {
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly AdvertsMyService _advertMyService;

        public AdvertsMyController(ApplicationUserManager applicationUserManager, AdvertsMyService advertMyService)
        {
            _applicationUserManager = applicationUserManager;
            _advertMyService = advertMyService;
        }

        [HttpGet]
        public async Task<IEnumerable<AdvertListResponse>> GetAllAsync()
        {
            string userId = _applicationUserManager.GetUserId(User);
            var response = await _advertMyService.GetAllAsync(userId);
            return null;
        }

        [HttpGet("{id}")]
        public async Task<AdvertsDetailsResponse> GetByIdAsync([FromRoute] string id)
        {
            var userEntity = await _applicationUserManager.GetUserAsync(User);
            var response = await _advertMyService.GetByIdAsync(id, userEntity);
            return null;
        }
    }
}