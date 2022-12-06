using Application.Contracts;
using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Courses.Queries.ByName;

public class GetCoursesQueryHandler : IQueryHandler<GetCourseByNameQuery, Result<GetCourseByNameResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCoursesQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<GetCourseByNameResponse>> Handle(GetCourseByNameQuery query, CancellationToken cancellationToken)
    {
        var courseOrNothing = await _unitOfWork.Courses.GetByName(query.Name);
        if (courseOrNothing.HasNoValue)
            return Result.Failure<GetCourseByNameResponse>($"There is no course for the given name");

        var course = courseOrNothing.Value;
        return Result.Success(new GetCourseByNameResponse()
        {
            Id = course.Id,
            Credits = course.Credits,
            Name = course.Name
        });
    }
}