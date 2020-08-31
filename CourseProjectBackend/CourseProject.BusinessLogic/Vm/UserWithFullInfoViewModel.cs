using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Vm
{
    public class UserWithFullInfoViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string RegisteredDate { get; set; }
    }
}
