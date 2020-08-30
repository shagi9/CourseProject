using CourseProject.BusinessLogic.Dto.CourseDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Templates;
using Templates.ViewModels;

namespace CourseProject.BusinessLogic.Services.Implementation
{
    public class BackgroundEmailSender : IBackgroundEmailSender
    {
        private readonly IEmailService emailService;
        private readonly IRazorViewToStringRenderer renderer;
        const string dayView = "/Views/Emails/ScheduledDayReminder";
        const string weekView = "/Views/Emails/ScheduledWeekReminder";
        const string monthView = "/Views/Emails/ScheduledMonthReminder";

        public BackgroundEmailSender(IEmailService emailService, IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            this.emailService = emailService;
            this.renderer = razorViewToStringRenderer;
        }

        public async Task ScheduledDay(string email, DateTime startDate, string courseName, string userName)
        {
            var model = new ScheduleViewModel(courseName, userName, startDate.ToString("dd/MM/yyyy"));

            string body = await renderer.RenderViewToStringAsync($"{dayView}.cshtml", model);
            
            BackgroundJob.Schedule(() =>
            emailService.SendEmailAsync(email, "Day Course notification", body), startDate - DateTime.Today - DateTime.Now.TimeOfDay);
        }

        public async Task ScheduledWeek(string email, DateTime startDate, string courseName, string userName)
        {
            var model = new ScheduleViewModel(courseName, userName, startDate.ToString("dd/MM/yyyy"));

            string body = await renderer.RenderViewToStringAsync($"{weekView}.cshtml", model);

            BackgroundJob.Schedule(() =>
            emailService.SendEmailAsync(email, "Weekly Course notification", body), startDate - DateTime.Today - DateTime.Now.TimeOfDay);
        }

        public async Task ScheduledMonth(string email, DateTime startDate, string courseName, string userName)
        {
            var model = new ScheduleViewModel(courseName, userName, startDate.ToString("dd/MM/yyyy"));

            string body = await renderer.RenderViewToStringAsync($"{monthView}.cshtml", model);

            BackgroundJob.Schedule(() =>
            emailService.SendEmailAsync(email, "Montly Course start", body), startDate - DateTime.Today - DateTime.Now.TimeOfDay);
        }
    }
}
