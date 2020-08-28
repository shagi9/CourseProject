using AutoMapper;
using CourseProject.BusinessLogic.Vm;
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
using CourseProject.BusinessLogic.Dto.AuthDto;
using Templates;
using Templates.ViewModels;

namespace CourseProject.BusinessLogic.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly DBContext context;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly IEmailService emailService;
        private readonly IRazorViewToStringRenderer razorViewToStringRenderer;
        const string view = "/Views/Emails/ConfirmAccountEmail";

        public AuthService(DBContext context, UserManager<User> userManager, 
            ITokenService tokenService, IMapper mapper, 
            IEmailService emailService, IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.emailService = emailService;
            this.razorViewToStringRenderer = razorViewToStringRenderer;
        }
        public async Task<LoginViewModel> Login(LoginDto loginModel)
        {
            var user = await userManager.FindByEmailAsync(loginModel.Login);

            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var emailConfirmationStatus = await userManager.IsEmailConfirmedAsync(user);
                
                if (!emailConfirmationStatus)
                {
                    return new LoginViewModel
                    {
                        IsEmailConfirmed = false
                    };
                }

                var userRoles = await userManager.GetRolesAsync(user);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, userRoles.First()),
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                var token = tokenService.GenerateJWT(claims);

                var refreshToken = tokenService.GenerateRefreshToken();
                await context.UserRefreshTokens.AddAsync(new UserRefreshToken
                {
                    UserId = user.Id,
                    RefreshToken = refreshToken,
                    Expires = DateTime.UtcNow.AddMonths(1)
                });
                await context.SaveChangesAsync();
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

            var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);

            var userIdStr = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userIdStr))
            {
                throw new SecurityTokenException($"Missing claim: {ClaimTypes.Name}!");
            }

            var userId = int.Parse(userIdStr);

            var userRefreshToken = await context.UserRefreshTokens
                .SingleOrDefaultAsync(user => user.UserId == userId && user.RefreshToken == refreshToken);

            if (userRefreshToken == null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            context.UserRefreshTokens.Remove(userRefreshToken);

            if (userRefreshToken.Expires < DateTime.UtcNow)
            {
                throw new SecurityTokenException("Token is expired");
            }

            var newJwtToken = tokenService.GenerateJWT(principal.Claims);
            var newRefreshToken = tokenService.GenerateRefreshToken();

            await context.UserRefreshTokens.AddAsync(new UserRefreshToken
            {
                UserId = userId,
                RefreshToken = newRefreshToken,
                Expires = DateTime.UtcNow.AddMonths(1)
            });
            await context.SaveChangesAsync();
            return new RefreshTokenViewModel(newJwtToken, newRefreshToken);
        }

        public async Task<IdentityResult> Register(RegisterDto registerDto)
        {
            var newUser = mapper.Map<User>(registerDto);

            var res = await userManager.CreateAsync(newUser, registerDto.Password);

            if (res.Succeeded)
            {
                await userManager.AddToRoleAsync(newUser, "student");

                var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(newUser);

                confirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));

                string confirmationLink = $"http://localhost:3000/confirmation/{newUser.Id}/{confirmationToken}";

                var confirmAccount = new ConfirmAccountEmailViewModel(confirmationLink);

                var toAddresses = newUser.Email;

                string body = await razorViewToStringRenderer.RenderViewToStringAsync($"{view}.cshtml", confirmAccount);

                await emailService.SendEmailAsync(toAddresses,
                    "Registration To The Course Project",
                   body);
            }

            return res;
        }

        public async Task<IdentityResult> VerifyEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            
            if (user == null || token == null)
            {
                return IdentityResult.Failed();
            }

            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

            var result = await userManager.ConfirmEmailAsync(user, token);
            return result;
        }
    }
}
