using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;

namespace Application.UseCases.Enrollments.Commands.Delete;

public class StudentDisenrollmentCommandHandler : ICommandHandler<StudentDisenrollmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentDisenrollmentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(StudentDisenrollmentCommand command, CancellationToken cancellationToken)
    {
        var studentOrNothing = await _unitOfWork.Students.GetById(command.Id);
        if (studentOrNothing.HasNoValue)
            return Result.Failure($"No student found for Id {command.Id}");

        var student = studentOrNothing.Value;
        if (string.IsNullOrWhiteSpace(command.Comment))
            return Result.Failure("Disenrollment comment is required");

        var enrollmentOrNothing = student.GetEnrollment(command.EnrollmentNumber);
        if (enrollmentOrNothing.HasNoValue)
            return Result.Failure($"No enrollment found with number '{command.EnrollmentNumber}'");

        student.RemoveEnrollment(enrollmentOrNothing.Value, command.Comment);
        
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}