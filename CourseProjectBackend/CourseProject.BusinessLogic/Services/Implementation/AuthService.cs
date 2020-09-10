using AutoMapper;
using CourseProject.BusinessLogic.Vm;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.DataAccess.DataContext;
using CourseProject.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
        private readonly IFacebookAuthService facebookAuthService;
        const string view = "/Views/Emails/ConfirmAccountEmail";

        public AuthService(DBContext context, UserManager<User> userManager, 
            ITokenService tokenService, IMapper mapper, 
            IEmailService emailService, IRazorViewToStringRenderer razorViewToStringRenderer,
            IFacebookAuthService facebookAuthService)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.emailService = emailService;
            this.razorViewToStringRenderer = razorViewToStringRenderer;
            this.facebookAuthService = facebookAuthService;
        }

        public async Task<LoginViewModel> LoginWithFacebookAsync(string accessToken)
        {
            var validatedTokenResult = await facebookAuthService.ValidateAccessTokenAsync(accessToken);

            if (!validatedTokenResult.Data.IsValid)
            {
                return null;
            }

            var userInfo = await facebookAuthService.GetUserInfoAsync(accessToken);

            var identityUser = await userManager.FindByEmailAsync(userInfo.Email);

            if (identityUser == null)
            {
                identityUser = new User
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    Email = userInfo.Email,
                    UserName = userInfo.FirstName + userInfo.LastName,
                    DateOfBirth = default(DateTime)
                };

                var createdResult = await userManager.CreateAsync(identityUser);
                if (!createdResult.Succeeded)
                {
                    return null;
                }

                await userManager.AddToRoleAsync(identityUser, "student");
            }

            var role = await userManager.GetRolesAsync(identityUser);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id.ToString()),
                new Claim(ClaimTypes.Role, role.First()),
                new Claim(ClaimTypes.Name, identityUser.UserName)
            };

            var token = tokenService.GenerateJWT(claims);
            return new LoginViewModel
            {
                IsEmailConfirmed = true,
                Token = token,
            };
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
                await context.SaveChangesAsync();
                return new LoginViewModel
                {
                    Token = token,
                    IsEmailConfirmed = true
                };
            }
            else
            {
                return null;
            }
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
