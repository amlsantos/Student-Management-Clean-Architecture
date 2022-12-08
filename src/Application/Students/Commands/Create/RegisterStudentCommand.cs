using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;

namespace Application.Students.Commands.Create;

public record RegisterStudentCommand : ICommand<Result>
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Course1 { get; init; }
    public string Course1Grade { get; init; }
    public string Course2 { get; init; }
    public string Course2Grade { get; init; }
}