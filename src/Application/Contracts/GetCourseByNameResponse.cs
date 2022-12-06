namespace Application.Contracts;

public record GetCourseByNameResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public int Credits { get; init; }
}