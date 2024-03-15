namespace EducationPlatform.Entities
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Course Course { get; set; }

    }

}
