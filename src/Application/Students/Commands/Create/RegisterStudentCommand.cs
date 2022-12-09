using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using StudentManagementSystem.Entities;

namespace Application.Students.Commands.Create;

public record RegisterStudentCommand : ICommand<Result>
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Course1 { get; init; }
    public string Course1Grade { get; init; }
    public string Course2 { get; init; }
    public string Course2Grade { get; init; }
}

public class RegisterStudentCommandHandler : ICommandHandler<RegisterStudentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterStudentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student(request.Name, request.Email);
        
        var courseOrNothing = await _unitOfWork.Courses.GetByName(request.Course1);
        if (courseOrNothing.HasNoValue)
            return Result.Failure($"There is no course for the given name: {request.Course1}");
        
        var canParseGrade = Enum.TryParse(request.Course1Grade, out Grade grade);
        if (!canParseGrade)
            return Result.Failure($"Grade is incorrect: '{request.Course1Grade}'");
        
        var enrollResult = student.Enroll(courseOrNothing.Value, grade);
        if (enrollResult.IsFailure)
            return Result.Failure(enrollResult.Error);

        courseOrNothing = await _unitOfWork.Courses.GetByName(request.Course2);
        if (courseOrNothing.HasNoValue)
            return Result.Failure($"There is no course for the given name: {request.Course2}");
        
        canParseGrade = Enum.TryParse(request.Course2Grade, out Grade grade2);
        if (!canParseGrade)
            return Result.Failure($"Grade is incorrect: '{request.Course2Grade}'");
        
        enrollResult = student.Enroll(courseOrNothing.Value, grade2);
        if (enrollResult.IsFailure)
            return Result.Failure(enrollResult.Error);

        await _unitOfWork.Students.SaveAsync(student);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}