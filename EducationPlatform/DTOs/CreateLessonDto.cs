﻿namespace EducationPlatform.DTOs
{
    public class CreateLessonDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
