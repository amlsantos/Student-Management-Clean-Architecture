using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using StudentManagementSystem.Entities;

namespace Application.Enrollments.Commands.Update;

public class TransferCommandHandler : ICommandHandler<StudentTransferCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public TransferCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(StudentTransferCommand request, CancellationToken cancellationToken)
    {
        var studentOrNothing = await _unitOfWork.Students.GetById(request.Id);
        if (studentOrNothing.HasNoValue)
            return Result.Failure($"No student found with Id '{request.Id}'");

        var courseOrNothing = await _unitOfWork.Courses.GetByName(request.Course);
        if (courseOrNothing.HasNoValue)
            return Result.Failure($"Course is incorrect: '{request.Course}'");

        var success = Enum.TryParse(request.Grade, out Grade grade);
        if (!success)
            return Result.Failure($"Grade is incorrect: '{request.Grade}'");

        var student = studentOrNothing.Value;
        
        var enrollmentOrNothing = student.GetEnrollment(request.EnrollmentNumber);
        if (enrollmentOrNothing.HasNoValue)
            return Result.Failure($"No enrollment found with number '{request.EnrollmentNumber}'");

        var course = courseOrNothing.Value;
        var enrollment = enrollmentOrNothing.Value;
        
        enrollment.UpdateCourse(course, grade);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}