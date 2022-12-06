using Application.Interfaces;
using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Enrollments.Commands.Create;

public record StudentEnrollCommand : ICommand<Result>
{
    public Guid Id { get; init; }
    public string Course { get; init; }
    public string Grade { get; init; }
}