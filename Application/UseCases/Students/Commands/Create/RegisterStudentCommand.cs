using Application.Interfaces;
using CSharpFunctionalExtensions;
using MediatR;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Students.Commands.Create;

public record RegisterStudentCommand : IRequest<Result>
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Course1 { get; init; }
    public string Course1Grade { get; init; }
    public string Course2 { get; init; }
    public string Course2Grade { get; init; }
}

public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterStudentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(RegisterStudentCommand command,
        CancellationToken cancellationToken)
    {
        var student = new Student(command.Name, command.Email);
        var course = await _unitOfWork.Courses.GetByName(command.Course1);
        
        if (course.HasNoValue)
            return Result.Failure($"There is no course for the given name: {command.Course1}");
        student.Enroll(course.Value, Enum.Parse<Grade>(command.Course1Grade));

        course = await _unitOfWork.Courses.GetByName(command.Course2);
        if (course.HasNoValue)
            return Result.Failure($"There is no course for the given name: {command.Course2}");
        student.Enroll(course.Value, Enum.Parse<Grade>(command.Course2Grade));

        await _unitOfWork.Students.SaveAsync(student);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}