using System.Collections.Generic;

namespace CourseProject.BusinessLogic.Vm
{
    public class PaginationUsersViewModel
    {
        public List<UserWithFullInfoViewModel> Users { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
