using AutoMapper;
using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        public string tokenToReturn;

        public AuthService(UserManager<User> userManager, ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<string> Login(LoginDto loginModel)
        {
            var login = await _userManager.FindByEmailAsync(loginModel.Login);
            
            if (login != null && await _userManager.CheckPasswordAsync(login, loginModel.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(login);
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, login.Id.ToString()),
                    new Claim(ClaimTypes.Role, userRoles.First()),
                    new Claim(ClaimTypes.Name, login.UserName)
                };
                
                tokenToReturn = _tokenService.GenerateJWT(claims);
            }
            return tokenToReturn;
        }

        public async Task<IdentityResult> Register(RegisterDto registerDto)
        {
            var newUser = _mapper.Map<User>(registerDto);

            var res = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "student");
            }
            
            return res;
        }
    }
}
