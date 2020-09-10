using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Vm;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginViewModel> Login(LoginDto loginModel);
        Task<LoginViewModel> LoginWithFacebookAsync(string accessToken);
        Task<IdentityResult> VerifyEmail(string userId, string token);
        Task<IdentityResult> Register(RegisterDto registerDto);
    }
}
