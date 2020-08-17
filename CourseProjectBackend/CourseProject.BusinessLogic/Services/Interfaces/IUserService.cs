using CourseProject.BusinessLogic.Dto.AuthDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
       Task<GetAutorizedUserDto> GetAutorizedByUser(string userId, string role);
    }
}
