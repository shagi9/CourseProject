using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CourseProject.DataAccess.Entities
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            RegistrationDate = DateTime.Now;
            CourseToUsers = new List<CourseToUser>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        public List<UserRefreshToken> UserRefreshTokens { get; set; }
        public List<CourseToUser> CourseToUsers {get; set;}
    }
}
