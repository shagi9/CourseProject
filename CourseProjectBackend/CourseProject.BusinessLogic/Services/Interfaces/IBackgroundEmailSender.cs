using CourseProject.BusinessLogic.Dto.CourseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface IBackgroundEmailSender
    {
        void ScheduledWeek(string email, DateTime startDate, string courseName);
        void ScheduledDay(string email, DateTime startDate, string courseName);
        void ScheduledMonth(string email, DateTime startDate, string courseName);
    }
}
