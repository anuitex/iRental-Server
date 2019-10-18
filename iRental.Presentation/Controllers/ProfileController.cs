using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iRental.Presentation.Controllers
{
    [Route("api/profile"), Authorize]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public ProfileController()
        {

        }

        [HttpGet("me")]
        public async Task GetMe()
        {

        }

        [HttpGet("{userId}")]
        public async Task GetUser([FromRoute]string userId)
        {

        }
    }
}