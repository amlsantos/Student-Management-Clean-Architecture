using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;

namespace Application.UseCases.Courses.Commands.Create;

public record CreateCourseCommand : ICommand<Result>
{
    public string Name { get; init; }
    public int Credits { get; init; }
}