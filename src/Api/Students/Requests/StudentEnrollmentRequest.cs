namespace Api.Students.Requests;

public record StudentEnrollmentRequest
{
    public string Course { get; set; }
    public string Grade { get; set; }
}