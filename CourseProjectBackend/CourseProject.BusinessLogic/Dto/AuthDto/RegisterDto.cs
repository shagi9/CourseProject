using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Dto.AuthDto
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
