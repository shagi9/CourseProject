using AutoMapper;
using AutoMapper.QueryableExtensions;
using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Dto.UsersDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.BusinessLogic.Vm;
using CourseProject.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var users = userManager.Users.Where(user =>
                user.UserName.ToLower().Contains(searchString) || user.FirstName.ToLower().Contains(searchString) ||
                user.LastName.ToLower().Contains(searchString) || user.Email.ToLower().Contains(searchString));

            pageInfo.TotalCount = users.Count();

            return users;
        }

        public IQueryable<User> GetUsersByOrderAndField(string orderByField, PageInfo pageInfo)
        {
            IQueryable<User> users = userManager.Users;

            var currentPage = pageInfo.CurrentPage - 1;
            var pageSize = pageInfo.PageSize;

            switch (orderByField)
            {
                case "id":
                    users = users.OrderBy(user => user.Id).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "userName":
                    users = users.OrderBy(user => user.UserName).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "email":
                    users = users.OrderBy(user => user.Email).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "fullName":
                    users = users.OrderBy(user => user.FirstName).ThenBy(user => user.LastName).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "dateOfBirth":
                    users = users.OrderBy(user => user.DateOfBirth).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                case "registrationDate":
                    users = users.OrderBy(user => user.RegistrationDate).Skip((currentPage) * pageSize).Take(pageSize);
                    break;
                default:
                    users = users.Skip((currentPage) * pageSize).Take(pageSize);
                    break;
            }

            return users;
        }

        public async Task<PaginationUsersViewModel> GetSortedUsers(DataForUsersSortDto data)
        {
            IQueryable<User> users = userManager.Users;

            var pageInfo = new PageInfo
            {
                CurrentPage = data.Current,
                PageSize = data.PageSize
            };

            if (!string.IsNullOrEmpty(data.SearchString))
            {
                users = GetUsersByData(data.SearchString.ToLower(), pageInfo);
            }
            else
            {
                pageInfo.TotalCount = userManager.Users.Count();
            }

            GetUsersByOrderAndField(data.Field, pageInfo);

            return new PaginationUsersViewModel
            {
                Users = await users.ProjectTo<UserWithFullInfoViewModel>(mapper.ConfigurationProvider).ToListAsync(),
                PageInfo = pageInfo
            };
        }

        public async Task<PaginationUsersViewModel> GetAllUsersWithFullInfo(PageInfo pageInfo)
        {
            var currentPage = pageInfo.CurrentPage - 1;
            var pageSize = pageInfo.PageSize;
            var users = await userManager.Users.Skip((currentPage) * pageSize).Take(pageSize).OrderBy(user => user.RegistrationDate)
                .ProjectTo<UserWithFullInfoViewModel>(mapper.ConfigurationProvider).ToListAsync();

            pageInfo.TotalCount = userManager.Users.Count();

            return new PaginationUsersViewModel { PageInfo = pageInfo, Users = users };
        }

        
    }
}
