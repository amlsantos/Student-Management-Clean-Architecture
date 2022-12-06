namespace Application.Contracts;

public record GetCoursesResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public int Credits { get; init; }
}