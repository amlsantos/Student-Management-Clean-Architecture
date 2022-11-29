namespace Application.UseCases.Enrollments.Commands.Create;

public record StudentsEnrollResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid CourseId { get; set; }
    public string CourseName { get; set; }

    public string Grade { get; set; }
}