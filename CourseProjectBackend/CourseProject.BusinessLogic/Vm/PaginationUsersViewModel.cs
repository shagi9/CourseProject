using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Vm
{
    public class PaginationUsersViewModel
    {
        public List<UserWithFullInfoViewModel> Users { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
