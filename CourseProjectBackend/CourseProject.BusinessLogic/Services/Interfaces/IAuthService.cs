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
        Task<string> Login(LoginDto loginModel);
        Task<IdentityResult> Register(RegisterDto registerDto);
    }
}
