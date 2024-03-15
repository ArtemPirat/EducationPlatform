namespace EducationPlatform.DTOs
{
    public class LessonDto
    {
        public int LessonId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
