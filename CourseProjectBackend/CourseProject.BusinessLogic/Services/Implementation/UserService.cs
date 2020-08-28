using AutoMapper;
using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
    }
}
