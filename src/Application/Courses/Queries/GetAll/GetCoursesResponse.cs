namespace Application.Courses.Queries.GetAll;

public record GetCoursesResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public int Credits { get; init; }
}