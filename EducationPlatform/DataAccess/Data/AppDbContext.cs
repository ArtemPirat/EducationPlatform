﻿using EducationPlatform.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationPlatform.DataAccess.Data
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Enrollments).WithOne(e => e.User);
            modelBuilder.Entity<Course>().HasMany(c => c.Lessons).WithOne(l => l.Course);
            modelBuilder.Entity<Enrollment>().HasKey(e => new { e.UserId, e.CourseId });


            base.OnModelCreating(modelBuilder);
        }
    }

}
