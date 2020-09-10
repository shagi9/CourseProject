using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.BusinessLogic.Vm.Facebook;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Implementation
{
    public class FacebookAuthService : IFacebookAuthService
    {
        private const string TokenValidationUrl = "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}";
        private const string UserInfoUrl = "https://graph.facebook.com/me?fields=first_name,last_name,picture,email&access_token={0}";
        private readonly IHttpClientFactory httpClientFactory;

        public FacebookAuthSettings Options { get; }
        public FacebookAuthService(IHttpClientFactory httpClientFactory,
            IOptions<FacebookAuthSettings> optionsAccessor)
        {
            this.httpClientFactory = httpClientFactory;
            Options = optionsAccessor.Value;
        }

        public async Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken)
        {
            var formattedUrl = string.Format(TokenValidationUrl, accessToken, Options.AppId,
                Options.AppSecret);

            var result = await httpClientFactory.CreateClient().GetAsync(formattedUrl);
            result.EnsureSuccessStatusCode();
            
            var responseAsString = await result.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<FacebookTokenValidationResult>(responseAsString);
        }

        public async Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken)
        {
            var formattedUrl = string.Format(UserInfoUrl, accessToken);

            var result = await httpClientFactory.CreateClient().GetAsync(formattedUrl);
            result.EnsureSuccessStatusCode();
            
            var responseAsString = await result.Content.ReadAsStringAsync();
           
            return JsonConvert.DeserializeObject<FacebookUserInfoResult>(responseAsString);
        }
    }
}
