using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using MediatR;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Enrollments.Commands.Create;

public class StudentEnrollCommandHandler : ICommandHandler<StudentEnrollCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentEnrollCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(StudentEnrollCommand command, CancellationToken cancellationToken)
    {
        var maybeStudent = await _unitOfWork.Students.GetById(command.Id);
        if (maybeStudent.HasNoValue)
            return Result.Failure($"No student found with given Id: '{command.Id}'");

        var maybeCourse = await _unitOfWork.Courses.GetByName(command.Course);
        if (maybeCourse.HasNoValue)
            return Result.Failure($"Course is incorrect: '{command.Course}'");

        var success = Enum.TryParse(command.Grade, out Grade grade);
        if (!success)
            return Result.Failure($"Grade is incorrect: '{command.Grade}'");

        var student = maybeStudent.Value;
        var course = maybeCourse.Value;
        
        student.Enroll(course, grade);
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }
}