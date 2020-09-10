using AutoMapper;
using AutoMapper.QueryableExtensions;
using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Dto.UsersDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.BusinessLogic.Vm;
using CourseProject.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<GetAutorizedUserDto> GetAutorizedByUser(string userId, string role)
        {
            var findUser = await userManager.FindByIdAsync(userId);

            var response = mapper.Map<GetAutorizedUserDto>(findUser);

            response.Role = role;

            return response;
        }
        public IQueryable<User> GetUsersByData(string searchString, PageInfo pageInfo)
        {
            var res = userManager.Users
                    .Where(x =>
                        x.UserName.ToLower().Contains(searchString) || x.FirstName.ToLower().Contains(searchString) ||
                        x.LastName.ToLower().Contains(searchString) || x.Email.ToLower().Contains(searchString) ||
                        x.PhoneNumber.Contains(searchString));

            pageInfo.Total = res.Count();

            return res;
        }

        public IQueryable<User> GetUsersByOrderDecent(string searchString, string orderBy, string orderByField, PageInfo pageInfo)
        {
            var users = GetUsersByData(searchString, pageInfo);
            pageInfo.Total = users.Count();

            var currentPage = pageInfo.Current - 1;
            var pageSize = pageInfo.PageSize;

            switch($"{orderByField} {orderBy}")
            {
                case "id descend":
                    users = users.OrderByDescending(user => user.Id).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "userName descend":
                    users = users.OrderByDescending(user => user.UserName).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "email descend":
                    users = users.OrderByDescending(user => user.Email).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "fullName ascend":
                    users = users.OrderBy(user => user.FirstName).ThenBy(user => user.LastName).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "dateOfBirth descend":
                    users = users.OrderByDescending(user => user.DateOfBirth).Skip((pageInfo.Current) * pageSize).Take(pageSize);
                    break;
                case "registrationDate descend":
                    users = users.OrderByDescending(user => user.RegistrationDate).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                default:
                    users = users.Skip((currentPage) * pageSize).Take(pageSize);
                    break;
            }

            return users;
        }

        public IQueryable<User> GetUsersByOrderAscend(string searchString, string orderBy, string orderByField, PageInfo pageInfo)
        {
            var users = GetUsersByData(searchString, pageInfo);

            pageInfo.Total = users.Count();

            var currentPage = pageInfo.Current - 1;
            var pageSize = pageInfo.PageSize;

            switch ($"{orderByField} {orderBy}")
            {
                case "id ascend":
                    users = users.OrderBy(user => user.Id).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "userName ascend":
                    users = users.OrderBy(user => user.UserName).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "email ascend":
                    users = users.OrderBy(user => user.Email).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "fullName ascend":
                    users = users.OrderBy(user => user.FirstName).ThenBy(user => user.LastName).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "dateOfBirth ascend":
                    users = users.OrderBy(user => user.DateOfBirth).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "registrationDate ascend":
                    users = users.OrderBy(user => user.RegistrationDate).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                default:
                    users = users.Skip((currentPage) * pageSize).Take(pageSize);
                    break;
            }

            return users;
        }

        public IQueryable<User> ClearUsersByData(PageInfo pageInfo)
        {
            var users = userManager.Users;

            pageInfo.Total = users.Count();
            pageInfo.Current = 1;

            users = users.Skip((pageInfo.Current - 1) * pageInfo.PageSize).Take(pageInfo.PageSize);

            return users;
        }

        public async Task<PaginationUsersViewModel> GetSortedUsers(DataForUsersSortDto data)
        {
            var users = userManager.Users;

            var pageInfo = new PageInfo
            {
                Current = data.Current,
                PageSize = data.PageSize
            };

            if (pageInfo.Current == 0)
            {
                users = ClearUsersByData(pageInfo);

                return (new PaginationUsersViewModel
                {
                    Users = await users.ProjectTo<UserWithFullInfoViewModel>(mapper.ConfigurationProvider).ToListAsync(),
                    PageInfo = pageInfo
                });
            }

            if (!string.IsNullOrEmpty(data.SearchString) || !string.IsNullOrEmpty(data.Order) || !string.IsNullOrEmpty(data.Field))
            {
                users = GetUsersByOrderDecent(data.SearchString, data.Order, data.Field, pageInfo);
            }

            if (!string.IsNullOrEmpty(data.SearchString) || !string.IsNullOrEmpty(data.Order) && !string.IsNullOrEmpty(data.Field))
            {
                users = GetUsersByOrderAscend(data.SearchString, data.Order, data.Field, pageInfo);
            }

            return new PaginationUsersViewModel
            {
                Users = await users.ProjectTo<UserWithFullInfoViewModel>(mapper.ConfigurationProvider).ToListAsync(),
                PageInfo = pageInfo
            };
        }

        public async Task<PaginationUsersViewModel> GetAllUsersWithFullInfo(PageInfo pageInfo)
        {
            var currentPage = pageInfo.Current - 1;
            var pageSize = pageInfo.PageSize;
            var users = await userManager.Users.Skip((currentPage) * pageSize).Take(pageSize).OrderBy(user => user.RegistrationDate)
                .ProjectTo<UserWithFullInfoViewModel>(mapper.ConfigurationProvider).ToListAsync();

            pageInfo.Total = userManager.Users.Count();

            return new PaginationUsersViewModel { PageInfo = pageInfo, Users = users };
        }

        public async Task<UserWithFullInfoViewModel> GetUserWithFullInfoById(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            return mapper.Map<UserWithFullInfoViewModel>(user);
        }
    }
}
