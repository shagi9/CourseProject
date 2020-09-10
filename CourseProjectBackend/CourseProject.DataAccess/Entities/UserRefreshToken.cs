using CourseProject.DataAccess.Entities.Base;
using System;

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
