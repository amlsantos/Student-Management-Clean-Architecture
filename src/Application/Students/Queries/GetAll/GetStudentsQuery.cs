using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using StudentManagementSystem.Entities;

namespace Application.Students.Queries.GetAll;

public record GetStudentsQuery : IQuery<List<GetStudentsResponse>>
{
    public string? EnrolledIn { get; init; }
    public int? NumberOfCourses { get; init; }
}

public class GetStudentsQueryHandler : IQueryHandler<GetStudentsQuery, List<GetStudentsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStudentsQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<List<GetStudentsResponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _unitOfWork
            .Students
            .GetStudentsWithCourses(request.EnrolledIn, request.NumberOfCourses);

        return students
            .Select(ToResponse)
            .ToList();
    }

    private GetStudentsResponse ToResponse(Student student)
    {
        var firstEnrollment = student.FirstEnrollment;
        var secondEnrollment = student.SecondEnrollment;
        
        return new GetStudentsResponse
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Course1 = firstEnrollment.HasValue ? firstEnrollment.Value.Course.Name : "-",
            Course1Grade = firstEnrollment.HasValue ? firstEnrollment.Value.Grade.ToString() : "-",
            Course1Credits = firstEnrollment.HasValue ? firstEnrollment.Value.Course.Credits : -1,
            Course2 = secondEnrollment.HasValue ? secondEnrollment.Value.Course.Name : "-",
            Course2Grade = secondEnrollment.HasValue ? secondEnrollment.Value.Grade.ToString() : "-",
            Course2Credits = secondEnrollment.HasValue ? secondEnrollment.Value.Course.Credits : -1,
        };
    }
}