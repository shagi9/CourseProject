using AutoMapper;
using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _mapper = mapper;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginDto>> Login([FromBody] LoginDto loginViewModel)
        {
            var response = await _authService.Login(loginViewModel);

            if (response == null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok(new { token = response });
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterDto>> Register([FromBody] RegisterDto user)
        {
            var createdUser = await _authService.Register(user);

            if (!createdUser.Succeeded)
            {
                return BadRequest(createdUser.Errors);
            }

            return Ok("User created");
        }
    }
}
