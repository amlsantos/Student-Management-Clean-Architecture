using Application.Interfaces;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Enrollments.Commands.Delete;

public record StudentDisenrollmentCommand : IRequest<Result<StudentDisenrollmentResponse>>
{
    public Guid Id { get; init; }
    public int EnrollmentNumber { get; init; }
    public string Comment { get; init; }
}

public class StudentDisenrollmentCommandHandler : IRequestHandler<StudentDisenrollmentCommand, Result<StudentDisenrollmentResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentDisenrollmentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<StudentDisenrollmentResponse>> Handle(StudentDisenrollmentCommand command, CancellationToken cancellationToken)
    {
        var studentOrNothing = await _unitOfWork.Students.GetById(command.Id);
        if (studentOrNothing.HasNoValue)
            return Result.Failure<StudentDisenrollmentResponse>($"No student found for Id {command.Id}");

        var student = studentOrNothing.Value;
        if (string.IsNullOrWhiteSpace(command.Comment))
            return Result.Failure<StudentDisenrollmentResponse>("Disenrollment comment is required");

        var enrollmentOrNothing = student.GetEnrollment(command.EnrollmentNumber);
        if (enrollmentOrNothing.HasNoValue)
            return Result.Failure<StudentDisenrollmentResponse>($"No enrollment found with number '{command.EnrollmentNumber}'");

        student.RemoveEnrollment(enrollmentOrNothing.Value, command.Comment);
        await _unitOfWork.CommitAsync();

        var response = new StudentDisenrollmentResponse()
        {
            StudentId = student.Id,
            StudentName = student.Name,
            Comment = command.Comment,
            CourseId = enrollmentOrNothing.Value.CourseId,
            CourseName = enrollmentOrNothing.Value.Course.Name,
            EnrollmentId = enrollmentOrNothing.Value.Id
        };

        return Result.Success(response);
    }
}