namespace Application.UseCases.Courses.Commands.Create;

public record CreateCourseCommandResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public int Credits { get; init; }
}