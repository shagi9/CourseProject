using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Dto.UsersDto
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
