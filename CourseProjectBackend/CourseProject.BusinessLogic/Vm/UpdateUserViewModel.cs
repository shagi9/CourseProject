using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Vm
{
    public class UpdateUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
