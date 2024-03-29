﻿using Api.Common;
using Api.Courses.Requests;
using Application.Courses.Commands.Create;
using Application.Courses.Queries.ById;
using Application.Courses.Queries.ByName;
using Application.Courses.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Courses;

[ApiController]
[Route("[controller]")]
public class CoursesController : BaseController
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetCoursesQuery();
        var response = await _mediator.Send(query);
        
        return Success(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetCourseByIdQuery { Id = id };
        var response = await _mediator.Send(query);

        return response.IsFailure ? Failure(response.Error) : Success(response.Value);
    }
    
    [HttpGet("[action]/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var query = new GetCourseByNameQuery { Name = name };
        var response = await _mediator.Send(query);

        return response.IsFailure ? Failure(response.Error) : Success(response.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseRequest request)
    {
        var command = new CreateCourseCommand { Name = request.Name, Credits = request.Credits };
        var response = await _mediator.Send(command);
        
        return response.IsFailure ? Failure(response.Error) : Success();
    }
}