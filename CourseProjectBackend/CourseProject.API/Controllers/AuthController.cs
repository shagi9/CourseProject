using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.BusinessLogic.Vm;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly ILoggerService loggerService;

        public AuthController(IAuthService authService, ILoggerService loggerService)
        {
            this.authService = authService;
            this.loggerService = loggerService;
        }

        [HttpPost("facebookAuth")]
        public async Task<ActionResult> Login([FromBody] FacebookAuthDto facebookAuthDto)
        {
            var authResponse = await authService.LoginWithFacebookAsync(facebookAuthDto.AccessToken);

            if (authResponse == null)
            {
                return BadRequest("Login with Facebook was failed.");
            }

            return Ok(authResponse);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginViewModel>> Login([FromBody] LoginDto loginViewModel)
        {
            var response = await authService.Login(loginViewModel);

            if (response == null)
            {
                loggerService.LogInfo("Invalid username or password");
                return BadRequest("Invalid username or password");
            }
            
            if (response.IsEmailConfirmed == false)
            {
                loggerService.LogInfo("Email is not confirmed");
                return NotFound("Please, confirm your email");
            }
            loggerService.LogInfo("User succesfuly logged in");
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterDto>> Register([FromBody] RegisterDto user)
        {
            var createdUser = await authService.Register(user);

            if (!createdUser.Succeeded)
            {
                loggerService.LogError("Something went wrong");
                return BadRequest(createdUser.Errors);
            }

            return Ok("Congratulations, you are successfully registered on.");
        }

        [HttpGet("verifyEmail")]
        public async Task<ActionResult<IdentityResult>> VerifyEmail(string userId, string token)
        {
            var response = await authService.VerifyEmail(userId, token);

            if (!response.Succeeded)
            {
                loggerService.LogError("Something went wrong");
                return BadRequest(response.Errors);
            }
            return Ok(response);
        }
    }
}
