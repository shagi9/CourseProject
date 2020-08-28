using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Services.Interfaces;
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
