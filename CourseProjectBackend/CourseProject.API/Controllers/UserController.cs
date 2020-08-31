using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Dto.UsersDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.BusinessLogic.Vm;
using CourseProject.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService service;

        public UserController(UserManager<User> userManager, IUserService service)
        {
            this.userManager = userManager;
            this.service = service;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("[action]")]
        public async Task<ActionResult<PaginationUsersViewModel>> GetSortedUsers(DataForUsersSortDto data)
        {
            var res = await service.GetSortedUsers(data);

            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("[action]")]
        public async Task<ActionResult<PaginationUsersViewModel>> GetAllUsersWithFullInfo([FromBody] PageInfo pageInfo)
        {
            var result = await service.GetAllUsersWithFullInfo(pageInfo);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-authorized-by-user")]
        public async Task<ActionResult<GetAutorizedUserDto>> GetAuthorized()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);

            var response = await service.GetAutorizedByUser(userId, role);
            
            return Ok(response);
        }
    }
}
