using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Courses.Commands.Create;

public class CreateCourseCommandHandler : ICommandHandler<CreateCourseCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCourseCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
    {
        var course = new Course { Name = command.Name, Credits = command.Credits };

        await _unitOfWork.Courses.AddAsync(course);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}