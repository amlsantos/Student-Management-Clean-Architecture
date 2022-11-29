namespace Api.Dtos;

public record CreateCourseRequest
{
    public string Name { get; set; }
    public int Credits { get; set; }
}