namespace Application.UseCases.Students.Commands.Update;

public record EditStudentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}