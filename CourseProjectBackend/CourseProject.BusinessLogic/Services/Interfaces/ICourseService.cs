using CourseProject.BusinessLogic.Dto.CourseDto;
using CourseProject.BusinessLogic.Vm;
using CourseProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BusinessLogic.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseViewModel>> GetAllCourses();
        Task<CourseViewModel> GetCourseById(int courseId);
        Task<bool> GetIsUserSubscribedToTheCourse(int courseId, int userId);
        Task<SubscribeToCourseViewModel> SubscribeToCourse(SubscribeToCourseDto subscribeToCourseDto);
        void ScheduledDate(string email, DateTime startDate, string courseName, string userName);
    }
}
