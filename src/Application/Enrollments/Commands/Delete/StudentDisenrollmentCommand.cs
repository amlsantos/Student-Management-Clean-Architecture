using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;

namespace Application.Enrollments.Commands.Delete;

public record StudentDisenrollmentCommand : ICommand<Result>
{
    public Guid Id { get; init; }
    public int EnrollmentNumber { get; init; }
    public string Comment { get; init; }
}