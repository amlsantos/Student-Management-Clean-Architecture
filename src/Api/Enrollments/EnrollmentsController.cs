using Api.Common;
using Application.Enrollments.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Enrollments;

[ApiController]
[Route("[controller]")]
public class EnrollmentsController : BaseController
{
    private readonly IMediator _mediator;

    public EnrollmentsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetEnrollmentsQuery();
        var response = await _mediator.Send(query);
        
        return Success(response);
    }
}