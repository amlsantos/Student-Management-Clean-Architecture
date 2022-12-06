using Application.Contracts;
using Application.Interfaces;
using Application.Interfaces.Messaging;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Courses.Queries.ByName;

public record GetCourseByNameQuery : IQuery<Result<GetCourseByNameResponse>>
{
    public string Name { get; set; }
}