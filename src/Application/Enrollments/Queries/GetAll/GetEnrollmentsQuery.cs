using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using StudentManagementSystem.Entities;

namespace Application.Enrollments.Queries.GetAll;

public record GetEnrollmentsQuery : IQuery<List<GetEnrollmentsResponse>>;

public class GetEnrollmentsQueryHandler : IQueryHandler<GetEnrollmentsQuery, List<GetEnrollmentsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetEnrollmentsQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    public async Task<List<GetEnrollmentsResponse>> Handle(GetEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        var enrollments = await _unitOfWork.Enrollments.GetAll();
        
        return enrollments
            .Select(ToResponse)
            .ToList();
    }

    private static GetEnrollmentsResponse ToResponse(Enrollment e)
    {
        return new GetEnrollmentsResponse
        {
            CourseId = e.CourseId,
            Grade = e.Grade.ToString(),
            CourseName = e.Course.Name,
            StudentId = e.StudentId,
            StudentName = e.Student.Name
        };
    }
}