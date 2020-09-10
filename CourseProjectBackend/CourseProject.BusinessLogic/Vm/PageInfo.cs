using System;

namespace CourseProject.BusinessLogic.Vm
{
    public class PageInfo
    {
        public int Current { get; set; } //current page
        public int PageSize { get; set; } //amount of objects on the page
        public int Total { get; set; } // amount of objects
        public int TotalPages => (int)Math.Ceiling((decimal)Total / PageSize); // all pages
    }
}
