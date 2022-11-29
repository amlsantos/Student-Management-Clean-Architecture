namespace Application.UseCases.Students.Commands.Create;

public record RegisterStudentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Guid Course1Id { get; set; }
    public string Course1Name { get; set; }
    public Guid Course2Id { get; set; }
    public string Course2Name { get; set; }
}