using Api.Dtos;
using Application.UseCases.Courses.Commands.Create;
using Application.UseCases.Courses.Queries.ById;
using Application.UseCases.Courses.Queries.ByName;
using Application.UseCases.Courses.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetCoursesQuery();
        var response = await _mediator.Send(query);
        
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetCourseByIdQuery() { Id = id };
        var response = await _mediator.Send(query);

        return response.IsFailure ? BadRequest(response.Error) : Ok(response.Value);
    }
    
    [HttpGet("[action]/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var query = new GetCourseByNameQuery { Name = name };
        var response = await _mediator.Send(query);

        return response.IsFailure ? BadRequest(response.Error) : Ok(response.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseRequest request)
    {
        var command = new CreateCourseCommand { Name = request.Name, Credits = request.Credits };
        var response = await _mediator.Send(command);

        return Ok(response);
    }
}