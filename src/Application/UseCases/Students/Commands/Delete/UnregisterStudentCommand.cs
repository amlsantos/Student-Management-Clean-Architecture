using Application.Interfaces;
using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Students.Commands.Delete;

public record UnregisterStudentCommand : ICommand<Result<string>>
{
    public Guid Id { get; init; }
}