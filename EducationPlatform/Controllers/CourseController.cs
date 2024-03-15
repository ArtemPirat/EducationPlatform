using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EducationPlatform.Interfaces;
using EducationPlatform.DTOs;

namespace EducationPlatform.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService; 

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var courses = _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] CreateCourseDto createCourseDto)
        {
            var course = _courseService.CreateCourse(createCourseDto);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] UpdateCourseDto updateCourseDto)
        {
            var updatedCourse = _courseService.UpdateCourse(id, updateCourseDto);
            if (updatedCourse == null)
            {
                return NotFound();
            }
            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var deletedCourse = _courseService.DeleteCourse(id);
            if (deletedCourse == null)
            {
                return NotFound();
            }
            return Ok(deletedCourse);
        }
    }
}
