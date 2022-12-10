using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;

namespace Application.Courses.Queries.ByName;

public record GetCourseByNameQuery : IQuery<Result<GetCourseByNameResponse>>
{
    public string Name { get; init; }
}

public class GetCoursesByNameQueryHandler : IQueryHandler<GetCourseByNameQuery, Result<GetCourseByNameResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCoursesByNameQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<GetCourseByNameResponse>> Handle(GetCourseByNameQuery request, CancellationToken cancellationToken)
    {
        var courseOrNothing = await _unitOfWork.Courses.GetByName(request.Name);
        if (courseOrNothing.HasNoValue)
            return Result.Failure<GetCourseByNameResponse>($"There is no course for the given name");

        var course = courseOrNothing.Value;
        var response = new GetCourseByNameResponse { Id = course.Id, Credits = course.Credits, Name = course.Name };
        
        return Result.Success(response);
    }
}