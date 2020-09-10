using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Dto.UsersDto;
using CourseProject.BusinessLogic.Vm;
using CourseProject.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
       Task<GetAutorizedUserDto> GetAutorizedByUser(string userId, string role);
       IQueryable<User> ClearUsersByData(PageInfo pageInfo);
       IQueryable<User> GetUsersByData(string searchString, PageInfo pageInfo);
       IQueryable<User> GetUsersByOrderDecent(string searchString, string orderBy, string orderByField, PageInfo pageInfo);
       IQueryable<User> GetUsersByOrderAscend(string searchString, string orderBy, string orderByField, PageInfo pageInfo);
       Task<PaginationUsersViewModel> GetAllUsersWithFullInfo(PageInfo pageInfo);
       Task<UserWithFullInfoViewModel> GetUserWithFullInfoById(string userId);
       Task<PaginationUsersViewModel> GetSortedUsers(DataForUsersSortDto data);
    }
}
