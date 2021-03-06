﻿using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Templates;

namespace CourseProject.BusinessLogic.Services.Implementation
{
    public class EmailService : IEmailService
    {
        public EmailService(IOptions<AuthMessageSenderOptions> optionsAccessor, 
            IRazorViewToStringRenderer renderer)
        {
            this.renderer = renderer;
            Options = optionsAccessor.Value;
        }

        private IRazorViewToStringRenderer renderer;

        public AuthMessageSenderOptions Options { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public async Task<Response> Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("shagoferov@gmail.com", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
                
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return await client.SendEmailAsync(msg);
        }
    }
}
