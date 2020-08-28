using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace CourseProject.BusinessLogic.Vm
{
    public class LoginViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool IsEmailConfirmed { get; set; }

    }
}
