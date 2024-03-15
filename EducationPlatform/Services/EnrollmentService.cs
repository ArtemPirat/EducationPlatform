using EducationPlatform.DTOs;
using EducationPlatform.Entities;
using EducationPlatform.Interfaces;

namespace EducationPlatform.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepository<Enrollment> _enrollmentRepository;

        public EnrollmentService(IRepository<Enrollment> enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public IEnumerable<EnrollmentDto> GetAllEnrollments()
        {
            var enrollments = _enrollmentRepository.GetAll();
            return enrollments.Select(e => new EnrollmentDto { EnrollmentId = e.EnrollmentId, UserId = e.UserId, CourseId = e.CourseId, EnrollmentDate = e.EnrollmentDate, IsCompleted = e.IsCompleted });
        }

        public EnrollmentDto GetEnrollmentById(int id)
        {
            var enrollment = _enrollmentRepository.GetById(id);
            return enrollment != null ? new EnrollmentDto { EnrollmentId = enrollment.EnrollmentId, UserId = enrollment.UserId, CourseId = enrollment.CourseId, EnrollmentDate = enrollment.EnrollmentDate, IsCompleted = enrollment.IsCompleted } : null;
        }

        public EnrollmentDto CreateEnrollment(CreateEnrollmentDto enrollmentDto)
        {
            var enrollment = new Enrollment { UserId = enrollmentDto.UserId, CourseId = enrollmentDto.CourseId, EnrollmentDate = DateTime.Now, IsCompleted = false };
            _enrollmentRepository.Add(enrollment);
            return new EnrollmentDto { EnrollmentId = enrollment.EnrollmentId, UserId = enrollment.UserId, CourseId = enrollment.CourseId, EnrollmentDate = enrollment.EnrollmentDate, IsCompleted = enrollment.IsCompleted };
        }

        public EnrollmentDto UpdateEnrollment(int id, UpdateEnrollmentDto enrollmentDto)
        {
            var existingEnrollment = _enrollmentRepository.GetById(id);
            if (existingEnrollment == null)
                return null;

            existingEnrollment.UserId = enrollmentDto.UserId;
            existingEnrollment.CourseId = enrollmentDto.CourseId;

            _enrollmentRepository.Update(existingEnrollment);

            return new EnrollmentDto { EnrollmentId = existingEnrollment.EnrollmentId, UserId = existingEnrollment.UserId, CourseId = existingEnrollment.CourseId, EnrollmentDate = existingEnrollment.EnrollmentDate, IsCompleted = existingEnrollment.IsCompleted };
        }

        public EnrollmentDto DeleteEnrollment(int id)
        {
            var enrollment = _enrollmentRepository.GetById(id);
            if (enrollment == null)
                return null;

            _enrollmentRepository.Delete(enrollment);
            return new EnrollmentDto { EnrollmentId = enrollment.EnrollmentId, UserId = enrollment.UserId, CourseId = enrollment.CourseId, EnrollmentDate = enrollment.EnrollmentDate, IsCompleted = enrollment.IsCompleted };
        }
    }
}
