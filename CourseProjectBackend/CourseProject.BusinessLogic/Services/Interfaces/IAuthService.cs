using CourseProject.BusinessLogic.Dto.AuthDto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginViewModel> Login(LoginDto loginModel);
        Task<RefreshTokenViewModel> RefreshToken(RefreshTokenViewModel token);
        Task<IdentityResult> VerifyEmail(string userId, string token);
        Task<IdentityResult> Register(RegisterDto registerDto);
    }
}
