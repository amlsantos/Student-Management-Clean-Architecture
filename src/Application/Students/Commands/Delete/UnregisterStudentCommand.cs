using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;

namespace Application.Students.Commands.Delete;

public record UnregisterStudentCommand : ICommand<Result<string>>
{
    public Guid Id { get; init; }
}