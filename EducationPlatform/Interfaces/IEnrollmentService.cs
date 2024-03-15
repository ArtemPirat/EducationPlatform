using EducationPlatform.DTOs;

namespace EducationPlatform.Interfaces
{
    public interface IEnrollmentService
    {
        IEnumerable<EnrollmentDto> GetAllEnrollments();
        EnrollmentDto GetEnrollmentById(int id);
        EnrollmentDto CreateEnrollment(CreateEnrollmentDto enrollmentDto);
        EnrollmentDto UpdateEnrollment(int id, UpdateEnrollmentDto enrollmentDto);
        EnrollmentDto DeleteEnrollment(int id);
    }
}
