namespace Application.UseCases.Enrollments.Queries.GetAll;

public record GetEnrollmentsResponse
{
    public Guid StudentId { get; init; }
    public string StudentName  { get; init; }
    
    public Guid CourseId { get; set; }
    public string CourseName  { get; init; }
    
    public string Grade { get; init; }
}