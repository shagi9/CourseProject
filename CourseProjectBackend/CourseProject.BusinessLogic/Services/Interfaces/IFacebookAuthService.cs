using CourseProject.BusinessLogic.Vm.Facebook;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface IFacebookAuthService
    {
        Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
        Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);
    }
}
