using Application.Interfaces;
using MediatR;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Courses.Commands.Create;

public record CreateCourseCommand : IRequest<CreateCourseCommandResponse>
{
    public string Name { get; init; }
    public int Credits { get; init; }
}

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCourseCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<CreateCourseCommandResponse> Handle(CreateCourseCommand query, CancellationToken cancellationToken)
    {
        var course = new Course()
        {
            Name = query.Name,
            Credits = query.Credits
        };

        await _unitOfWork.Courses.AddAsync(course);
        await _unitOfWork.CommitAsync();

        return new CreateCourseCommandResponse()
        {
            Id = course.Id,
            Name = course.Name,
            Credits = course.Credits
        };
    }
}