using System;

namespace Templates.ViewModels
{
    public class SubscribeViewModel
    {
        public string CourseName { get; set; }
        public string UserName { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public SubscribeViewModel(string courseName, string userName, string startDate, string endDate)
        {
            CourseName = courseName;
            UserName = userName;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}