using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CourseProject.BusinessLogic.Dto.AuthDto
{
    public class RefreshTokenViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public RefreshTokenViewModel() : this("", "") { }
        public RefreshTokenViewModel(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}
