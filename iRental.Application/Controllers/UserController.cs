using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iRental.Application.ViewModels;
using iRental.Domain.Models;
using iRental.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iRental.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get(int pageSize,int pageNumber)
        {
            var users = await _userRepository.QueryAsync(new BaseQuery(pageSize, pageNumber));
            var userViews = users.Select(user => new UserView(user));
            return Ok(userViews);
        }
    }
}
