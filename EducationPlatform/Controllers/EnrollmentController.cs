using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EducationPlatform.DTOs;
using EducationPlatform.Interfaces;

namespace EducationPlatform.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService; 

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public IActionResult GetAllEnrollments()
        {
            var enrollments = _enrollmentService.GetAllEnrollments();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public IActionResult GetEnrollmentById(int id)
        {
            var enrollment = _enrollmentService.GetEnrollmentById(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost]
        public IActionResult CreateEnrollment([FromBody] CreateEnrollmentDto createEnrollmentDto)
        {
            var enrollment = _enrollmentService.CreateEnrollment(createEnrollmentDto);
            return CreatedAtAction(nameof(GetEnrollmentById), new { id = enrollment.EnrollmentId }, enrollment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEnrollment(int id, [FromBody] UpdateEnrollmentDto updateEnrollmentDto)
        {
            var updatedEnrollment = _enrollmentService.UpdateEnrollment(id, updateEnrollmentDto);
            if (updatedEnrollment == null)
            {
                return NotFound();
            }
            return Ok(updatedEnrollment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            var deletedEnrollment = _enrollmentService.DeleteEnrollment(id);
            if (deletedEnrollment == null)
            {
                return NotFound();
            }
            return Ok(deletedEnrollment);
        }
    }
}
