using Application.Contracts;
using Application.Interfaces;
using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Courses.Queries.ById;

public record GetCourseByIdQuery : IQuery<Result<GetCourseByIdResponse>>
{
    public Guid Id { get; set; }
}