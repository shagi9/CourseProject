using System.Collections.Generic;
using System.Security.Claims;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJWT(IEnumerable<Claim> Claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
