namespace Application.UseCases.Courses.Queries.ById;

public record GetCourseByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public int Credits { get; init; }
}