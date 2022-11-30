using Application.Interfaces;
using CSharpFunctionalExtensions;
using MediatR;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Courses.Commands.Create;

public record CreateCourseCommand : IRequest<Result>
{
    public string Name { get; init; }
    public int Credits { get; init; }
}

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCourseCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateCourseCommand query, CancellationToken cancellationToken)
    {
        var course = new Course { Name = query.Name, Credits = query.Credits };

        await _unitOfWork.Courses.AddAsync(course);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}