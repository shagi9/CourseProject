using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace CourseProject.DataAccess.Entities
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            RegistrationDate = DateTime.Now;
            CourseToUsers = new List<CourseToUser>();
            Courses = new List<Course>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        public List<UserRefreshToken> UserRefreshTokens { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseToUser> CourseToUsers {get; set;}
    }
}
