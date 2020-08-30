﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CourseProject.BusinessLogic.Dto.CourseDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.BusinessLogic.Vm;
using CourseProject.DataAccess.DataContext;
using CourseProject.DataAccess.Entities;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templates;
using Templates.ViewModels;

namespace CourseProject.BusinessLogic.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly IBackgroundEmailSender backgroundEmailSender;
        private readonly IEmailService emailService;
        private readonly DBContext context;
        private readonly IMapper mapper;
        private readonly IRazorViewToStringRenderer renderer;
        private readonly UserManager<User> userManager;
        const string view = "/Views/Emails/SubscribeToCourse";

        public CourseService(DBContext context, IMapper mapper, 
            IBackgroundEmailSender backgroundEmailSender, 
            IEmailService emailService, 
            IRazorViewToStringRenderer razorViewToStringRenderer, UserManager<User> userManager)
        {
            this.backgroundEmailSender = backgroundEmailSender;
            this.emailService = emailService;
            this.context = context;
            this.mapper = mapper;
            this.renderer = razorViewToStringRenderer;
            this.userManager = userManager;
        }
        public async Task<List<CourseViewModel>> GetAllCourses()
        {
            return await context.Courses.OrderByDescending(course => course.Id)
                .ProjectTo<CourseViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CourseViewModel> GetCourseById(int courseId)
        {
            var course = await context.Courses.FindAsync(courseId);

            return mapper.Map<CourseViewModel>(course);
        }

        public async Task<bool> GetIsUserSubscribedToTheCourse(int courseId, int userId)
        {
            return await context.CoursesToUsers.FirstOrDefaultAsync(x => x.CourseId == courseId && x.UserId == userId) != null;
        }

        public async Task<SubscribeToCourseViewModel> SubscribeToCourse(SubscribeToCourseDto subscribe)
        {
            var courseToUser = mapper.Map<CourseToUser>(subscribe);

            if (courseToUser != null && await GetIsUserSubscribedToTheCourse(courseToUser.CourseId, courseToUser.UserId) == false)
            { 
                 context.CoursesToUsers.Add(courseToUser);

                 await context.SaveChangesAsync();

                 courseToUser = await context.CoursesToUsers
                    .Include(course => course.Course)
                    .Include(user => user.User)
                    .FirstOrDefaultAsync(course => course.CourseId == courseToUser.CourseId && course.UserId == courseToUser.UserId);

                var model = new SubscribeViewModel(courseToUser.Course.Name, 
                    courseToUser.User.UserName, courseToUser.StartDate.ToString("dd/MM/yyyy"), 
                    courseToUser.EndDate.ToString("dd/MM/yyyy"));
                
                string body = await renderer.RenderViewToStringAsync($"{view}.cshtml", model);

                await emailService.SendEmailAsync(courseToUser.User.Email, "Registration To The Course", body);

                // method for schedule
                ScheduledDate(courseToUser.User.Email, courseToUser.StartDate, courseToUser.Course.Name, courseToUser.User.UserName);

                return mapper.Map<SubscribeToCourseViewModel>(courseToUser);
            } else
            {
                return null;
            }
        }

        public void ScheduledDate(string email, DateTime startDate, string courseName, string userName)
        {
            var dayDate = startDate.AddDays(-1).Add(new TimeSpan(8, 0, 0));
            var weekDate = startDate.AddDays(-7);
            var monthDate = startDate.AddMonths(-1);

            if (weekDate > DateTime.Today)
            {
                backgroundEmailSender.ScheduledWeek(email, weekDate, courseName, userName);
            }

            if (dayDate > DateTime.Today.Add(new TimeSpan(8, 0, 0)))
            {
                backgroundEmailSender.ScheduledDay(email, dayDate, courseName, userName);
            }

            if (monthDate > DateTime.Today)
            {
                backgroundEmailSender.ScheduledMonth(email, monthDate, courseName, userName);
            }
        }
    }
}
