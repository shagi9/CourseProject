using System;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface IBackgroundEmailSender
    {
        Task ScheduledWeek(string email, DateTime weekDate, string courseName, string userName);
        Task ScheduledDay(string email, DateTime dayDate, string courseName, string userName);
        Task ScheduledMonth(string email, DateTime monthDate, string courseName, string userName);
    }
}
