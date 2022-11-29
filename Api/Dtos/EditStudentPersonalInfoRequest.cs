namespace Api.Dtos;

public record EditStudentPersonalInfoRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
}