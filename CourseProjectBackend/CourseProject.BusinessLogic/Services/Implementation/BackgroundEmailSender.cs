using CourseProject.BusinessLogic.Dto.CourseDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Services.Implementation
{
    public class BackgroundEmailSender : IBackgroundEmailSender
    {
        private readonly IEmailService emailService;

        public BackgroundEmailSender(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public void ScheduledWeek(string email, DateTime startDate, string courseName)
        {
            var weekNotify = startDate;
            BackgroundJob.Schedule(() =>
            emailService.SendEmailAsync(email, "Weekly Course notification", $"Your course {courseName} will start at {startDate}"), weekNotify - DateTime.Today - DateTime.Now.TimeOfDay);
        }

        public void ScheduledDay(string email, DateTime startDate, string courseName)
        {
            var dayNotify = startDate;
            BackgroundJob.Schedule(() =>
            emailService.SendEmailAsync(email, "Day Course notification", $"Your course {courseName} will start at {startDate}"), dayNotify - DateTime.Today - DateTime.Now.TimeOfDay);
        }

        public void ScheduledMonth(string email, DateTime startDate, string courseName)
        {
            var monthNotify = startDate;
            BackgroundJob.Schedule(() =>
            emailService.SendEmailAsync(email, "Montly Course start", $"Your course {courseName} will start at {startDate}"), monthNotify - DateTime.Today - DateTime.Now.TimeOfDay);
        }
    }
}
