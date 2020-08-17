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
            CourseToStudents = new List<CourseToUser>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<CourseToUser> CourseToStudents { get; set; }

    }
}
