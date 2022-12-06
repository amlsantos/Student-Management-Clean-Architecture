using Application.Contracts;
using Application.Interfaces;
using Application.Interfaces.Messaging;
using MediatR;

namespace Application.UseCases.Students.Queries.GetAll;

public record GetStudentsQuery : IQuery<List<GetStudentsResponse>>
{
    public string? EnrolledIn { get; init; }
    public int? NumberOfCourses { get; init; }
}