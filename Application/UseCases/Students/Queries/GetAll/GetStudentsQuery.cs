using Application.Interfaces;
using MediatR;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Students.Queries.GetAll;

public record GetStudentsQuery : IRequest<List<GetStudentsResponse>>
{
    public string EnrolledIn { get; init; }
    public int? NumberOfCourses { get; init; }
}

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<GetStudentsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStudentsQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<List<GetStudentsResponse>> Handle(GetStudentsQuery query, CancellationToken cancellationToken)
    {
        var students = await _unitOfWork.Students.GetStudentsWithCourses(query.EnrolledIn, query.NumberOfCourses);

        return students.Select(x => ConvertToDto(x)).ToList();
    }

    private GetStudentsResponse ConvertToDto(Student student)
    {
        return new GetStudentsResponse
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Course1 = student.FirstEnrollment.Value.Course?.Name,
            Course1Grade = student.FirstEnrollment.Value.Grade.ToString(),
            Course1Credits = student.FirstEnrollment.Value.Course?.Credits,
            Course2 = student.SecondEnrollment.Value.Course?.Name,
            Course2Grade = student.SecondEnrollment.Value.Grade.ToString(),
            Course2Credits = student.SecondEnrollment.Value.Course?.Credits,
        };
    }
}