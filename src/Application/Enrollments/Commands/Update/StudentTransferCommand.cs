using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;

namespace Application.Enrollments.Commands.Update;

public record StudentTransferCommand : ICommand<Result>
{
    public Guid Id { get; init; }
    public int EnrollmentNumber { get; init; }
    public string Course { get; init; }
    public string Grade { get; init; }
}