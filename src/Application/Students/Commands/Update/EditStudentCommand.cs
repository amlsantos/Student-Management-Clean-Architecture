using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;

namespace Application.Students.Commands.Update;

public record EditStudentCommand : ICommand<Result>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
}