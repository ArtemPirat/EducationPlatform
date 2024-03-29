﻿namespace EducationPlatform.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

}
