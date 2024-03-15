using EducationPlatform.DTOs;

namespace EducationPlatform.Interfaces
{
    public interface ILessonService
    {
        IEnumerable<LessonDto> GetAllLessons();
        LessonDto GetLessonById(int id);
        LessonDto CreateLesson(CreateLessonDto lessonDto);
        LessonDto UpdateLesson(int id, UpdateLessonDto lessonDto);
        LessonDto DeleteLesson(int id);
    }
}
