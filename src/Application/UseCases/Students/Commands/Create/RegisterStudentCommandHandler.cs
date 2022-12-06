using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Students.Commands.Create;

public class RegisterStudentCommandHandler : ICommandHandler<RegisterStudentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterStudentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(RegisterStudentCommand command, CancellationToken cancellationToken)
    {
        var student = new Student(command.Name, command.Email);
        
        var course = await _unitOfWork.Courses.GetByName(command.Course1);
        if (course.HasNoValue)
            return Result.Failure($"There is no course for the given name: {command.Course1}");
        
        var success = Enum.TryParse(command.Course1Grade, out Grade grade);
        if (!success)
            return Result.Failure($"Grade is incorrect: '{command.Course1Grade}'");
        student.Enroll(course.Value, grade);

        course = await _unitOfWork.Courses.GetByName(command.Course2);
        if (course.HasNoValue)
            return Result.Failure($"There is no course for the given name: {command.Course2}");
        
        success = Enum.TryParse(command.Course2Grade, out Grade grade2);
        if (!success)
            return Result.Failure($"Grade is incorrect: '{command.Course2Grade}'");
        student.Enroll(course.Value, grade2);

        await _unitOfWork.Students.SaveAsync(student);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}