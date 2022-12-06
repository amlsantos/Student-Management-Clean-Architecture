using Application.Contracts;
using Application.Interfaces;
using Application.Interfaces.Messaging;
using MediatR;

namespace Application.UseCases.Courses.Queries.GetAll;

public record GetCoursesQuery : IQuery<List<GetCoursesResponse>>;