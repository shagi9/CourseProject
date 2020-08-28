using AutoMapper;
using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.BusinessLogic.Vm;
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
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginViewModel>> Login([FromBody] LoginDto loginViewModel)
        {
            var response = await authService.Login(loginViewModel);

            if (response == null)
            {
                return BadRequest("Invalid username or password");
            }
            
            if (response.IsEmailConfirmed == false)
            {
                return NotFound("Please, confirm your email");
            }

            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<RefreshTokenViewModel>> RefreshToken(RefreshTokenViewModel token)
        {
            var response = await authService.RefreshToken(token);

            if (response == null)
            {
                return Unauthorized("You are not unathorized");
            }
            return Ok(response);

        }


        [HttpPost("register")]
        public async Task<ActionResult<RegisterDto>> Register([FromBody] RegisterDto user)
        {
            var createdUser = await authService.Register(user);

            if (!createdUser.Succeeded)
            {
                return BadRequest(createdUser.Errors);
            }

            return Ok("User created");
        }

        [HttpGet("verifyEmail")]
        public async Task<ActionResult<IdentityResult>> VerifyEmail(string userId, string token)
        {
            var response = await authService.VerifyEmail(userId, token);

            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response);
        }
    }
}
