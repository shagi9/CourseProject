using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Vm
{
    public class SubscribeToCourseViewModel
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
