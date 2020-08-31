using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Dto.UsersDto;
using CourseProject.BusinessLogic.Vm;
using CourseProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
       Task<GetAutorizedUserDto> GetAutorizedByUser(string userId, string role);
       IQueryable<User> GetUsersByData(string searchString, PageInfo pageInfo);
       IQueryable<User> GetUsersByOrderAndField(string orderByField, PageInfo pageInfo);
       Task<PaginationUsersViewModel> GetAllUsersWithFullInfo(PageInfo pageInfo);
       Task<PaginationUsersViewModel> GetSortedUsers(DataForUsersSortDto data);
    }
}
