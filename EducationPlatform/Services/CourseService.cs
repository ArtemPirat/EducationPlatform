using EducationPlatform.DTOs;
using EducationPlatform.Entities;
using EducationPlatform.Interfaces;

namespace EducationPlatform.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository; 

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<CourseDto> GetAllCourses()
        {
            var courses = _courseRepository.GetAll();
            return courses.Select(c => new CourseDto { CourseId = c.CourseId, Title = c.Title });
        }

        public CourseDto GetCourseById(int id)
        {
            var course = _courseRepository.GetById(id);
            return course != null ? new CourseDto { CourseId = course.CourseId, Title = course.Title } : null;
        }

        public CourseDto CreateCourse(CreateCourseDto courseDto)
        {
            var course = new Course { Title = courseDto.Title };
            _courseRepository.Add(course);
            return new CourseDto { CourseId = course.CourseId, Title = course.Title };
        }

        public CourseDto UpdateCourse(int id, UpdateCourseDto courseDto)
        {
            var existingCourse = _courseRepository.GetById(id);
            if (existingCourse == null)
                return null;

            existingCourse.Title = courseDto.Title;
            _courseRepository.Update(existingCourse);

            return new CourseDto { CourseId = existingCourse.CourseId, Title = existingCourse.Title };
        }

        public CourseDto DeleteCourse(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
                return null;

            _courseRepository.Delete(course);
            return new CourseDto { CourseId = course.CourseId, Title = course.Title };
        }
    }
}
