using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iRental.BusinessLogicLayer.Services;
using iRental.ViewModel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iRental.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly AdvertService _advertService;

        public AdvertsController(AdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet]
        public async Task<IEnumerable<AdvertListResponse>> GetAllForUserAsync()
        {
            string userId = "";
            var response = await _advertService.GetAllForUserAsync(userId);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<AdvertsDetailsResponse> GetMoreByIdAsync([FromRoute] string id)
        {
            string userId = "";
            var response = await _advertService.GetMoreByIdAsync(id, userId);
            return response;
        }

        [HttpPut]
        public async Task CreateAsync(AdvertCreateRequest requst)
        {
            string userId = "";
            await _advertService.CreateAsync(requst, userId);
        }
    }
}
