using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EducationPlatform.DTOs;
using EducationPlatform.Interfaces;

namespace EducationPlatform.Controllers
{
    [ApiController]
    [Route("api/lessons")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public IActionResult GetAllLessons()
        {
            var lessons = _lessonService.GetAllLessons();
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public IActionResult GetLessonById(int id)
        {
            var lesson = _lessonService.GetLessonById(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return Ok(lesson);
        }

        [HttpPost]
        public IActionResult CreateLesson([FromBody] CreateLessonDto createLessonDto)
        {
            var lesson = _lessonService.CreateLesson(createLessonDto);
            return CreatedAtAction(nameof(GetLessonById), new { id = lesson.LessonId }, lesson);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLesson(int id, [FromBody] UpdateLessonDto updateLessonDto)
        {
            var updatedLesson = _lessonService.UpdateLesson(id, updateLessonDto);
            if (updatedLesson == null)
            {
                return NotFound();
            }
            return Ok(updatedLesson);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLesson(int id)
        {
            var deletedLesson = _lessonService.DeleteLesson(id);
            if (deletedLesson == null)
            {
                return NotFound();
            }
            return Ok(deletedLesson);
        }
    }
}
