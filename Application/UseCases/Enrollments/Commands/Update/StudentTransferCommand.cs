using Application.Interfaces;
using CSharpFunctionalExtensions;
using MediatR;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Enrollments.Commands.Update;

public record StudentTransferCommand : IRequest<Result<StudentTransferResponse>>
{
    public Guid Id { get; init; }
    public int EnrollmentNumber { get; init; }
    public string Course { get; init; }
    public string Grade { get; init; }
}

public class TransferCommandHandler : IRequestHandler<StudentTransferCommand, Result<StudentTransferResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public TransferCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<StudentTransferResponse>> Handle(StudentTransferCommand command, CancellationToken cancellationToken)
    {
        var studentOrNothing = await _unitOfWork.Students.GetById(command.Id);
        if (studentOrNothing.HasNoValue)
            return Result.Failure<StudentTransferResponse>($"No student found with Id '{command.Id}'");

        var courseOrNothing = await _unitOfWork.Courses.GetByName(command.Course);
        if (courseOrNothing.HasNoValue)
            return Result.Failure<StudentTransferResponse>($"Course is incorrect: '{command.Course}'");

        var success = Enum.TryParse(command.Grade, out Grade grade);
        if (!success)
            return Result.Failure<StudentTransferResponse>($"Grade is incorrect: '{command.Grade}'");

        var student = studentOrNothing.Value;
        var enrollmentOrNothing = student.GetEnrollment(command.EnrollmentNumber);
        if (enrollmentOrNothing.HasNoValue)
            return Result.Failure<StudentTransferResponse>($"No enrollment found with number '{command.EnrollmentNumber}'");

        var course = courseOrNothing.Value;
        var enrollment = enrollmentOrNothing.Value;
        
        enrollment.Update(course, grade);
        await _unitOfWork.CommitAsync();

        var response = new StudentTransferResponse()
        {
            Id = student.Id,
            Name = student.Name,
            CourseId = course.Id,
            CourseName = course.Name
        };

        return Result.Success(response);
    }
}