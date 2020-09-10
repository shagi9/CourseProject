using AutoMapper;
using AutoMapper.QueryableExtensions;
using CourseProject.BusinessLogic.Dto.CourseDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.BusinessLogic.Vm;
using CourseProject.DataAccess.DataContext;
using CourseProject.DataAccess.Entities;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly IWebHostEnvironment host;

        public CourseService(DBContext context, IMapper mapper, 
            IBackgroundEmailSender backgroundEmailSender, 
            IEmailService emailService, 
            IRazorViewToStringRenderer razorViewToStringRenderer, 
            UserManager<User> userManager, IWebHostEnvironment host)
        {
            this.backgroundEmailSender = backgroundEmailSender;
            this.emailService = emailService;
            this.context = context;
            this.mapper = mapper;
            this.renderer = razorViewToStringRenderer;
            this.userManager = userManager;
            this.host = host;
        }
        public async Task<List<CourseViewModel>> GetAllCourses()
        {
            return await context.Courses.OrderByDescending(course => course.Id)
                .ProjectTo<CourseViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<CourseToUserViewModel>> GetCoursesByUserId(int userId)
        {
            var courses = await context.CoursesToUsers
                .Where(course => course.UserId == userId).OrderBy(course => course.StartDate)
                .ProjectTo<CourseToUserViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return courses;
        }

        public async Task<List<CourseToUserViewModel>> GetCoursesByUserEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var courses = await context.CoursesToUsers
                    .Where(users => users.UserId == user.Id).ProjectTo<CourseToUserViewModel>(mapper.ConfigurationProvider)
                    .ToListAsync();

                return courses;
            }
            return null;
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

        public async Task<CourseViewModel> AddCourseByAdmin(AddCourseDto addCourse)
        {
            var newCourse = mapper.Map<Course>(addCourse);
            if (addCourse.File != null)
            {
                var photoFolderPath = Path.Combine(host.WebRootPath, "Images");
                if (!Directory.Exists(photoFolderPath))
                {
                    Directory.CreateDirectory(photoFolderPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(addCourse.File.FileName);

                var filePath = Path.Combine(photoFolderPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await addCourse.File.CopyToAsync(stream);
                }
                
                newCourse.ImgUrl = fileName;
                
                await context.Courses.AddAsync(newCourse);
                await context.SaveChangesAsync();

                return mapper.Map<CourseViewModel>(newCourse);
            } else
            {
                return null;
            }
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

        public async void ScheduledDate(string email, DateTime startDate, string courseName, string userName)
        {
            var dayDate = startDate.AddDays(-1).Add(new TimeSpan(8, 0, 0));
            var weekDate = startDate.AddDays(-7);
            var monthDate = startDate.AddMonths(-1);

            if (weekDate > DateTime.Today)
            {
                await backgroundEmailSender.ScheduledWeek(email, weekDate, courseName, userName);
            }

            if (dayDate > DateTime.Today.Add(new TimeSpan(8, 0, 0)))
            {
                await backgroundEmailSender.ScheduledDay(email, dayDate, courseName, userName);
            }

            if (monthDate > DateTime.Today)
            {
                await backgroundEmailSender.ScheduledMonth(email, monthDate, courseName, userName);
            }
        }
    }
}
