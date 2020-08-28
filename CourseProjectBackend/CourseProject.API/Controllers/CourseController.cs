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
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "student")]
        public async Task<ActionResult<CourseViewModel>> GetCourseById(int courseId)
        {
            var response = await courseService.GetCourseById(courseId);

            if (response == null)
            {
                return NotFound("We don't have that course");
            }

            return Ok(response);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "student")]
        public async Task<ActionResult<List<CourseViewModel>>> GetAllCourses()
        {
            var response = await courseService.GetAllCourses();

            return Ok(response);
        }

        [HttpPost("action")]
        [Authorize(Roles = "student")]
        public async Task<ActionResult<SubscribeToCourseViewModel>> SubscribeToCourse([FromBody] SubscribeToCourseDto subscribeToCourse)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            subscribeToCourse.UserId = userId;

            var response = await courseService.SubscribeToCourse(subscribeToCourse);

            if (response == null)
            {
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
                return BadRequest("User is not subscribed to this course");
            }

            return Ok("User is subscribed to this course");
        }
    }
}
