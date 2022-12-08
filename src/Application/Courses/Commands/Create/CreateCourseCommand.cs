using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using StudentManagementSystem.Entities;

namespace Application.Courses.Commands.Create;

public record CreateCourseCommand : ICommand<Result>
{
    public string Name { get; init; }
    public int Credits { get; init; }
}

public class CreateCourseCommandHandler : ICommandHandler<CreateCourseCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCourseCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course(request.Name, request.Credits);

        await _unitOfWork.Courses.AddAsync(course);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}