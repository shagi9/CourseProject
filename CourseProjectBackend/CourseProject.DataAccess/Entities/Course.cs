using CourseProject.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.DataAccess.Entities
{
    public class Course : EntityBase
    {
        public Course()
        {
            CourseToUsers = new List<CourseToUser>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public List<CourseToUser> CourseToUsers { get; set; }

    }
}
