using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;

namespace Application.Enrollments.Commands.Delete;

public record StudentDisenrollmentCommand : ICommand<Result>
{
    public Guid Id { get; init; }
    public int EnrollmentNumber { get; init; }
    public string Comment { get; init; }
}

public class StudentDisenrollmentCommandHandler : ICommandHandler<StudentDisenrollmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentDisenrollmentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(StudentDisenrollmentCommand request, CancellationToken cancellationToken)
    {
        var studentOrNothing = await _unitOfWork.Students.GetById(request.Id);
        if (studentOrNothing.HasNoValue)
            return Result.Failure($"No student found for Id {request.Id}");

        var student = studentOrNothing.Value;
        if (string.IsNullOrWhiteSpace(request.Comment))
            return Result.Failure("Disenrollment comment is required");

        var enrollmentOrNothing = student.GetEnrollment(request.EnrollmentNumber);
        if (enrollmentOrNothing.HasNoValue)
            return Result.Failure($"No enrollment found with number '{request.EnrollmentNumber}'");

        student.RemoveEnrollment(enrollmentOrNothing.Value, request.Comment);
        
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}