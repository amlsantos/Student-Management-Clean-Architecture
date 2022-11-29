using Application.Interfaces;
using CSharpFunctionalExtensions;
using MediatR;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Enrollments.Commands.Create;

public record StudentEnrollCommand : IRequest<Result<StudentsEnrollResponse>>
{
    public Guid Id { get; init; }
    public string Course { get; init; }
    public string Grade { get; init; }
}

public class StudentEnrollCommandHandler : IRequestHandler<StudentEnrollCommand, Result<StudentsEnrollResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentEnrollCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<StudentsEnrollResponse>> Handle(StudentEnrollCommand command, CancellationToken cancellationToken)
    {
        var maybeStudent = await _unitOfWork.Students.GetById(command.Id);
        if (maybeStudent.HasNoValue)
            return Result.Failure<StudentsEnrollResponse>($"No student found with Id '{command.Id}'");

        var maybeCourse = await _unitOfWork.Courses.GetByName(command.Course);
        if (maybeCourse.HasNoValue)
            return Result.Failure<StudentsEnrollResponse>($"Course is incorrect: '{command.Course}'");

        var success = Enum.TryParse(command.Grade, out Grade grade);
        if (!success)
            return Result.Failure<StudentsEnrollResponse>($"Grade is incorrect: '{command.Grade}'");

        var student = maybeStudent.Value;
        var course = maybeCourse.Value;
        
        student.Enroll(course, grade);
        await _unitOfWork.CommitAsync();

        var response = new StudentsEnrollResponse()
        {
            Id = student.Id,
            Name = student.Name,
            CourseId = course.Id,
            CourseName = course.Name,
            Grade = grade.ToString()
        };
        
        return Result.Success(response);
    }
}