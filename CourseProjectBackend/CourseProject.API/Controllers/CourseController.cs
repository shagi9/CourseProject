using CourseProject.BusinessLogic.Dto.CourseDto;
using CourseProject.BusinessLogic.Services.Interfaces;
using CourseProject.BusinessLogic.Vm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly ILoggerService loggerService;

        public CourseController(ICourseService courseService, ILoggerService loggerService)
        {
            this.courseService = courseService;
            this.loggerService = loggerService;
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "student")]
        public async Task<ActionResult<CourseViewModel>> GetCourseById(int courseId)
        {
            var course = await courseService.GetCourseById(courseId);

            if (course == null)
            {
                loggerService.LogError("Course is null");
                return NotFound("We don't have that course");
            }
            return Ok(course);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "student")]
        public async Task<ActionResult<List<CourseViewModel>>> GetAllCourses()
        {
            var courses = await courseService.GetAllCourses();

            return Ok(courses);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "student")]
        public async Task<ActionResult<SubscribeToCourseViewModel>> SubscribeToCourse([FromBody] SubscribeToCourseDto subscribeToCourse)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            subscribeToCourse.UserId = userId;

            var response = await courseService.SubscribeToCourse(subscribeToCourse);

            if (response == null)
            {
                loggerService.LogError("Error");
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "student")]
        public async Task<IActionResult> GetIsUserSubscribedToTheCourse(int courseId)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var response = await courseService.GetIsUserSubscribedToTheCourse(courseId, userId);

            if (!response)
            {
                loggerService.LogError("User is not subscribed");
                return BadRequest("User is not subscribed to this course");
            }

            return Ok("User is subscribed to this course");
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<List<CourseToUserViewModel>>> GetCoursesByUserId(int userId)
        {
            var response = await courseService.GetCoursesByUserId(userId);

            return Ok(response);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<List<CourseToUserViewModel>>> GetCoursesByStudentEmail(string email)
        {
            var courses = await courseService.GetCoursesByUserEmail(email);

            if (courses != null)
            {
                loggerService.LogError("User is not found with this email");
                return Ok(courses);
            }

            return BadRequest();
        }
    }
}
