namespace Application.UseCases.Enrollments.Commands.Update;

public record StudentTransferResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }  
}