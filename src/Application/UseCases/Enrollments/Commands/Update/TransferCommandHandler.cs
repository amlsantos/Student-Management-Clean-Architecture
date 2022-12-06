using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using MediatR;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Enrollments.Commands.Update;

public class TransferCommandHandler : ICommandHandler<StudentTransferCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public TransferCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(StudentTransferCommand command, CancellationToken cancellationToken)
    {
        var studentOrNothing = await _unitOfWork.Students.GetById(command.Id);
        if (studentOrNothing.HasNoValue)
            return Result.Failure($"No student found with Id '{command.Id}'");

        var courseOrNothing = await _unitOfWork.Courses.GetByName(command.Course);
        if (courseOrNothing.HasNoValue)
            return Result.Failure($"Course is incorrect: '{command.Course}'");

        var success = Enum.TryParse(command.Grade, out Grade grade);
        if (!success)
            return Result.Failure($"Grade is incorrect: '{command.Grade}'");

        var student = studentOrNothing.Value;
        
        var enrollmentOrNothing = student.GetEnrollment(command.EnrollmentNumber);
        if (enrollmentOrNothing.HasNoValue)
            return Result.Failure($"No enrollment found with number '{command.EnrollmentNumber}'");

        var course = courseOrNothing.Value;
        var enrollment = enrollmentOrNothing.Value;
        
        enrollment.Update(course, grade);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}