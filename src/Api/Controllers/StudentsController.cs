using Api.Contracts;
using Api.Controllers.Common;
using Application.UseCases.Enrollments.Commands.Create;
using Application.UseCases.Enrollments.Commands.Delete;
using Application.UseCases.Enrollments.Commands.Update;
using Application.UseCases.Students.Commands.Create;
using Application.UseCases.Students.Commands.Delete;
using Application.UseCases.Students.Commands.Update;
using Application.UseCases.Students.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : BaseController
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetList(string? enrolled, int? number)
    {
        var query = new GetStudentsQuery { EnrolledIn = enrolled, NumberOfCourses = number };
        var response = await _mediator.Send(query);

        return Success(response);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterStudentRequest request)
    {
        var command = new RegisterStudentCommand
        { Name = request.Name, Email = request.Email, Course1 = request.Course1, Course1Grade = request.Course1Grade, 
            Course2 = request.Course2, Course2Grade = request.Course2Grade };

        var response = await _mediator.Send(command);
        return response.IsFailure ? Failure(response.Error) : Success();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Unregister(Guid id)
    {
        var command = new UnregisterStudentCommand { Id = id };
        var response = await _mediator.Send(command);

        return response.IsFailure ? Failure(response.Error) : Success(response.Value);
    }

    [HttpPost("{id}/enrollments")]
    public async Task<IActionResult> Enroll(Guid id, [FromBody] StudentEnrollmentRequest request)
    {
        var command = new StudentEnrollCommand { Id = id, Course = request.Course, Grade = request.Grade };
        var response = await _mediator.Send(command);

        return response.IsFailure ? Failure(response.Error) : Success();
    }

    [HttpPut("{id}/enrollments/{enrollmentNumber}")]
    public async Task<IActionResult> Transfer(Guid id, int enrollmentNumber, [FromBody] StudentTransferRequest request)
    {
        var command = new StudentTransferCommand { Id = id, EnrollmentNumber = enrollmentNumber, Course = request.Course, Grade = request.Grade };
        var response = await _mediator.Send(command);

        return response.IsFailure ? Failure(response.Error) : Success();
    }

    [HttpPost("{id}/enrollments/{enrollmentNumber}/deletion")]
    public async Task<IActionResult> Disenroll(Guid id, int enrollmentNumber, [FromBody] StudentDisenrollmentRequest request)
    {
        var command = new StudentDisenrollmentCommand { Id = id, EnrollmentNumber = enrollmentNumber, Comment = request.Comment };
        var response = await _mediator.Send(command);

        return response.IsFailure ? Failure(response.Error) : Success();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditPersonalInfo(Guid id, [FromBody] EditStudentPersonalInfoRequest request)
    {
        var command = new EditStudentCommand { Id = id, Name = request.Name, Email = request.Email };
        var response = await _mediator.Send(command);

        return response.IsFailure ? Failure(response.Error) : Success();
    }
}