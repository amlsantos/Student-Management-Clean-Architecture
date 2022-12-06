using Application.Interfaces;
using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Enrollments.Commands.Delete;

public record StudentDisenrollmentCommand : ICommand<Result>
{
    public Guid Id { get; init; }
    public int EnrollmentNumber { get; init; }
    public string Comment { get; init; }
}