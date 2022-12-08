using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using StudentManagementSystem.Entities;

namespace Application.Enrollments.Commands.Create;

public class StudentEnrollCommandHandler : ICommandHandler<StudentEnrollCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentEnrollCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(StudentEnrollCommand request, CancellationToken cancellationToken)
    {
        var maybeStudent = await _unitOfWork.Students.GetById(request.Id);
        if (maybeStudent.HasNoValue)
            return Result.Failure($"No student found with given Id: '{request.Id}'");

        var maybeCourse = await _unitOfWork.Courses.GetByName(request.Course);
        if (maybeCourse.HasNoValue)
            return Result.Failure($"Course is incorrect: '{request.Course}'");

        var success = Enum.TryParse(request.Grade, out Grade grade);
        if (!success)
            return Result.Failure($"Grade is incorrect: '{request.Grade}'");

        var student = maybeStudent.Value;
        var course = maybeCourse.Value;
        
        student.Enroll(course, grade);
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }
}