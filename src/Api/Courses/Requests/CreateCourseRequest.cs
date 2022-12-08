namespace Api.Courses.Requests;

public record CreateCourseRequest
{
    public string Name { get; set; }
    public int Credits { get; set; }
}