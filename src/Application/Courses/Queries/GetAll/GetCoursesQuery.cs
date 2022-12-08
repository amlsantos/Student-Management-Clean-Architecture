using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using StudentManagementSystem.Entities;

namespace Application.Courses.Queries.GetAll;

public record GetCoursesQuery : IQuery<List<GetCoursesResponse>>;

public class GetCoursesQueryHandler : IQueryHandler<GetCoursesQuery, List<GetCoursesResponse>>, IRetryableRequest<GetCoursesQuery, List<GetCoursesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCoursesQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<List<GetCoursesResponse>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.Courses.GetAll();
        return courses
            .Select(ToResponse)
            .ToList();
    }
    
    GetCoursesResponse ToResponse(Course c)
    {
        return new GetCoursesResponse
        {
            Id = c.Id, 
            Name = c.Name, 
            Credits = c.Credits
        };
    }
}