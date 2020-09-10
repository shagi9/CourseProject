using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Dto.CourseDto
{
    public class AddCourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
