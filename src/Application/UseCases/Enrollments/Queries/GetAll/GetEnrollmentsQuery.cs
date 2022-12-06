using Application.Contracts;
using Application.Interfaces;
using Application.Interfaces.Messaging;
using MediatR;

namespace Application.UseCases.Enrollments.Queries.GetAll;

public record GetEnrollmentsQuery : IQuery<List<GetEnrollmentsResponse>>;