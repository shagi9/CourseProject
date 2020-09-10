using CourseProject.DataAccess.Entities.Base;
using System.Collections.Generic;

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
        public List<CourseToUser> CourseToUsers { get; set; }
    }
}
