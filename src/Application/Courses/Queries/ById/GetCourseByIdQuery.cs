using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;

namespace Application.Courses.Queries.ById;

public record GetCourseByIdQuery : IQuery<Result<GetCourseByIdResponse>>
{
    public Guid Id { get; set; }
}

public class GetCourseByIdQueryHandler : IQueryHandler<GetCourseByIdQuery, Result<GetCourseByIdResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetCourseByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    public async Task<Result<GetCourseByIdResponse>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var courseOrNothing = await _unitOfWork.Courses.GetById(request.Id);
        if (courseOrNothing.HasNoValue)
            return Result.Failure<GetCourseByIdResponse>($"There is no course for the given id {request.Id}");
        
        var course = courseOrNothing.Value;
        var response = new GetCourseByIdResponse { Id = course.Id, Credits = course.Credits, Name = course.Name };
        
        return Result.Success(response);
    }
}