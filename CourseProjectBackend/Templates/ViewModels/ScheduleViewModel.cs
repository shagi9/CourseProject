using System;

namespace Templates.ViewModels
{
    public class ScheduleViewModel
    {
        public string CourseName { get; set; }
        public string UserName { get; set; }
        public string StartDate { get; set; }

        public ScheduleViewModel(string courseName, string userName, string startDate)
        {
            CourseName = courseName;
            UserName = userName;
            StartDate = startDate;
        }
    }
}