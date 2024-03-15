using EducationPlatform.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPlatform.DataAccess.Data.Configurations
{
    public class EnrollmentEntityConfigs : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.UserId, e.CourseId });
            builder.Property(e => e.EnrollmentId).ValueGeneratedOnAdd();
            builder.Property(e => e.EnrollmentDate).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.IsCompleted).IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // Додайте інші властивості та конфігурації, якщо потрібно

            builder.ToTable("Enrollments");
        }
    }
}
