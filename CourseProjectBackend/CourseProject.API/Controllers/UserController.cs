﻿using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Dto.UsersDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.BusinessLogic.Vm;
using CourseProject.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize(Roles = "admin")]
        [HttpDelete("[action]")]
        public async Task<ActionResult<UserWithFullInfoViewModel>> DeleteUser(string userId)
        {
            var result = await service.DeleteUser(userId);

            if (result == null)
            {
                return BadRequest("User not found");
            }

            return Ok("User is deleted");
        }

        [Authorize(Roles = "admin")]
        [HttpPut("[action]")]
        public async Task<ActionResult<User>> UpdateUser(UpdateUserDto updateUser)
        {
            var result = await service.UpdateUser(updateUser);
            
            if (result == null)
            {
                return NotFound(result);
            }
            
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

        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<UserWithFullInfoViewModel>> GetUserWithFullInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await service.GetUserWithFullInfoById(userId);

            if (response == null)
            {
                return BadRequest("User not found");
            }

            return Ok(response);
        }


    }
}
