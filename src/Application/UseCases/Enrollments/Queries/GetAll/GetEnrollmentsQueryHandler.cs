using Application.Contracts;
using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using MediatR;

namespace Application.UseCases.Enrollments.Queries.GetAll;

public class GetEnrollmentsQueryHandler : IQueryHandler<GetEnrollmentsQuery, List<GetEnrollmentsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetEnrollmentsQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    public async Task<List<GetEnrollmentsResponse>> Handle(GetEnrollmentsQuery query, CancellationToken cancellationToken)
    {
        var enrollments = await _unitOfWork.Enrollments.GetAll();

        return enrollments.Select(e => new GetEnrollmentsResponse()
        {
            CourseId = e.CourseId,
            Grade = e.Grade.ToString(),
            CourseName = e.Course.Name,
            StudentId = e.StudentId,
            StudentName = e.Student.Name
        }).ToList();
    }
}