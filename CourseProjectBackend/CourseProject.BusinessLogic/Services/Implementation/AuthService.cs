using AutoMapper;
using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.DataAccess.DataContext;
using CourseProject.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        public string tokenToReturn;

        public AuthService(DBContext context, UserManager<User> userManager, 
            ITokenService tokenService, IMapper mapper, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
            _emailService = emailService;
        }
        public async Task<LoginViewModel> Login(LoginDto loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Login);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var emailConfirmationStatus = await _userManager.IsEmailConfirmedAsync(user);
                
                if (!emailConfirmationStatus)
                {
                    return new LoginViewModel
                    {
                        IsEmailConfirmed = false
                    };
                }

                var userRoles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, userRoles.First()),
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                var token = _tokenService.GenerateJWT(claims);

                var refreshToken = _tokenService.GenerateRefreshToken();
                await _context.UserRefreshTokens.AddAsync(new UserRefreshToken
                {
                    UserId = user.Id,
                    RefreshToken = refreshToken,
                    Expires = DateTime.UtcNow.AddMonths(1)
                });
                await _context.SaveChangesAsync();
                return new LoginViewModel
                {
                    Token = token,
                    RefreshToken = refreshToken,
                    IsEmailConfirmed = true
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<RefreshTokenViewModel> RefreshToken(RefreshTokenViewModel token)
        {
            string accessToken = token.Token;
            string refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var userIdStr = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userIdStr))
            {
                throw new SecurityTokenException($"Missing claim: {ClaimTypes.Name}!");
            }

            var userId = int.Parse(userIdStr);

            var userRefreshToken = await _context.UserRefreshTokens
                .SingleOrDefaultAsync(u => u.UserId == userId && u.RefreshToken == refreshToken);

            if (userRefreshToken == null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            _context.UserRefreshTokens.Remove(userRefreshToken);

            if (userRefreshToken.Expires < DateTime.UtcNow)
            {
                throw new SecurityTokenException("Token is expired");
            }

            var newJwtToken = _tokenService.GenerateJWT(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            await _context.UserRefreshTokens.AddAsync(new UserRefreshToken
            {
                UserId = userId,
                RefreshToken = newRefreshToken,
                Expires = DateTime.UtcNow.AddMonths(1)
            });
            await _context.SaveChangesAsync();
            return new RefreshTokenViewModel(newJwtToken, newRefreshToken);
        }

        public async Task<IdentityResult> Register(RegisterDto registerDto)
        {
            var newUser = _mapper.Map<User>(registerDto);

            var res = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "student");

                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

                string confirmationLink = $"https://localhost:5001/confirmation/{newUser.Id}/{confirmationToken}";

                await _emailService.SendEmailAsync(newUser.Email,
                    "Registration Successful",
                    $"<h1>Hello, {newUser.UserName}</h1>" +
                    $"<h2>Before you can Login,<br>Please confirm your email by clicking on the <a href='{confirmationLink}'>link</a> and start learning!</h2>" +
                    "<h2>Have a nice day.</h2>");
            }

            return res;
        }

        public async Task<IdentityResult> VerifyEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user == null || token == null)
            {
                return IdentityResult.Failed();
            }
          
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result;
        }
    }
}
