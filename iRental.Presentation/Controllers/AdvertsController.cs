using iRental.BusinessLogicLayer.Identity;
using iRental.BusinessLogicLayer.Services;
using iRental.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iRental.Presentation.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly AdvertService _advertService;
        private readonly ApplicationUserManager _applicationUserManager;

        public AdvertsController(AdvertService advertService, ApplicationUserManager applicationUserManager)
        {
            _advertService = advertService;
            _applicationUserManager = applicationUserManager;
        }

        [HttpPut]
        public async Task CreateAsync(AdvertCreateRequest requst)
        {
            string userId = _applicationUserManager.GetUserId(User);
            await _advertService.CreateAsync(requst, userId);
        }
    }
}
