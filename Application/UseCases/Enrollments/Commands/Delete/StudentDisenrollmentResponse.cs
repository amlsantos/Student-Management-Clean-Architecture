namespace Application.UseCases.Enrollments.Commands.Delete;

public record StudentDisenrollmentResponse
{
    public Guid StudentId { get; set; }
    public string StudentName { get; set; }
    public Guid EnrollmentId { get; set; }
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
    public string Comment { get; set; }
}