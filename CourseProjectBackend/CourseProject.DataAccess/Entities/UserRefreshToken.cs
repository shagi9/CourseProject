using CourseProject.DataAccess.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.DataAccess.Entities
{
    public class UserRefreshToken : EntityBase
    {
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
