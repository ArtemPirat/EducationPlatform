using EducationPlatform.DTOs;
using EducationPlatform.Entities;
using EducationPlatform.Interfaces;

namespace EducationPlatform.Services
{
    public class LessonService : ILessonService
    {
        private readonly IRepository<Lesson> _lessonRepository;

        public LessonService(IRepository<Lesson> lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public IEnumerable<LessonDto> GetAllLessons()
        {
            var lessons = _lessonRepository.GetAll();
            return lessons.Select(l => new LessonDto { LessonId = l.LessonId, Title = l.Title, Content = l.Content });
        }

        public LessonDto GetLessonById(int id)
        {
            var lesson = _lessonRepository.GetById(id);
            return lesson != null ? new LessonDto { LessonId = lesson.LessonId, Title = lesson.Title, Content = lesson.Content } : null;
        }

        public LessonDto CreateLesson(CreateLessonDto lessonDto)
        {
            var lesson = new Lesson { Title = lessonDto.Title, Content = lessonDto.Content, StartTime = lessonDto.StartTime, EndTime = lessonDto.EndTime };
            _lessonRepository.Add(lesson);
            return new LessonDto { LessonId = lesson.LessonId, Title = lesson.Title, Content = lesson.Content };
        }

        public LessonDto UpdateLesson(int id, UpdateLessonDto lessonDto)
        {
            var existingLesson = _lessonRepository.GetById(id);
            if (existingLesson == null)
                return null;

            existingLesson.Title = lessonDto.Title;
            existingLesson.Content = lessonDto.Content;
            existingLesson.StartTime = lessonDto.StartTime;
            existingLesson.EndTime = lessonDto.EndTime;

            _lessonRepository.Update(existingLesson);

            return new LessonDto { LessonId = existingLesson.LessonId, Title = existingLesson.Title, Content = existingLesson.Content };
        }

        public LessonDto DeleteLesson(int id)
        {
            var lesson = _lessonRepository.GetById(id);
            if (lesson == null)
                return null;

            _lessonRepository.Delete(lesson);
            return new LessonDto { LessonId = lesson.LessonId, Title = lesson.Title, Content = lesson.Content };
        }
    }
}
