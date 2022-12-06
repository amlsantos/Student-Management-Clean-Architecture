using Application.Contracts;
using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Courses.Queries.ById;

public class GetCourseByIdQueryHandler : IQueryHandler<GetCourseByIdQuery, Result<GetCourseByIdResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetCourseByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    public async Task<Result<GetCourseByIdResponse>> Handle(GetCourseByIdQuery query, CancellationToken cancellationToken)
    {
        var courseOrNothing = await _unitOfWork.Courses.GetById(query.Id);
        if (courseOrNothing.HasNoValue)
            return Result.Failure<GetCourseByIdResponse>($"There is no course for the given id {query.Id}");
        
        var course = courseOrNothing.Value;
        return Result.Success(new GetCourseByIdResponse()
        {
            Id = course.Id,
            Credits = course.Credits,
            Name = course.Name
        });
    }
}