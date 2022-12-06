using Application.Interfaces;
using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Students.Commands.Update;

public record EditStudentCommand : ICommand<Result>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
}