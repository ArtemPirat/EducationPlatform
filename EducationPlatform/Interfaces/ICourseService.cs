using EducationPlatform.DTOs;

namespace EducationPlatform.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetAllCourses();
        CourseDto GetCourseById(int id);
        CourseDto CreateCourse(CreateCourseDto courseDto);
        CourseDto UpdateCourse(int id, UpdateCourseDto courseDto);
        CourseDto DeleteCourse(int id);
    }
}
