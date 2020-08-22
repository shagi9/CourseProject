using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace CourseProject.BusinessLogic.Dto.AuthDto
{
    public class LoginViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool IsEmailConfirmed { get; set; }

    }
}
