using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Vm
{
    public class PageInfo
    {
        public int CurrentPage { get; set; } //current page
        public int PageSize { get; set; } //amount of objects on the page
        public int TotalCount { get; set; } // amount of objects
        public int TotalPages => (int)Math.Ceiling((decimal)TotalCount / PageSize); // all pages
    }
}
