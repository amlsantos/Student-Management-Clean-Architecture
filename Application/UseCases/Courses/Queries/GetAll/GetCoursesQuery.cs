using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Courses.Queries.GetAll;

public record GetCoursesQuery : IRequest<List<GetCoursesResponse>>;

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<GetCoursesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCoursesQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<List<GetCoursesResponse>> Handle(GetCoursesQuery query, CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.Courses.GetAll();

        return courses.Select(c => new GetCoursesResponse()
        {
            Id = c.Id,
            Name = c.Name,
            Credits = c.Credits
        }).ToList();
    }
}