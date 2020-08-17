using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJWT(List<Claim> Claims);
    }
}
