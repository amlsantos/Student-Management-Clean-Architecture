using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;

namespace Application.Enrollments.Commands.Create;

public record StudentEnrollCommand : ICommand<Result>
{
    public Guid Id { get; init; }
    public string Course { get; init; }
    public string Grade { get; init; }
}