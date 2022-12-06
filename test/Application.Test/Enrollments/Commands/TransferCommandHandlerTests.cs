using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using Application.UseCases.Enrollments.Commands.Update;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Enrollments.Commands;

public class TransferCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly ICommandHandler<StudentTransferCommand, Result> _handler;

    public TransferCommandHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new TransferCommandHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_InvalidStudent_ReturnsFailResult()
    {
        // arrange
        var id = Guid.NewGuid(); var command = new StudentTransferCommand { Id = id };
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe<Student>.None);

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("No student found");
    }
    
    [Fact]
    public async Task Handle_InvalidCourse_ReturnsFailResult()
    {
        // arrange
        var id = Guid.NewGuid(); var course = string.Empty; 
        var command = new StudentTransferCommand { Id = id, Course = course };
        
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.From(new Student()));
        _unitOfWork.Setup(u => u.Courses.GetByName(course)).ReturnsAsync(Maybe.None);

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("Course is incorrect");
    }
    
    [Fact]
    public async Task Handle_InvalidGrade_ReturnsFailResult()
    {
        // arrange
        var id = Guid.NewGuid(); var course = string.Empty; var grade = "aa";
        var command = new StudentTransferCommand { Id = id, Course = course, Grade = grade };
        
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.From(new Student()));
        _unitOfWork.Setup(u => u.Courses.GetByName(course)).ReturnsAsync(Maybe.From(new Course()));

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("Grade is incorrect");
    }
    
    [Fact]
    public async Task Handle_InvalidEnrollment_ReturnsFailResult()
    {
        // arrange
        var id = Guid.NewGuid(); var courseName = "math"; var grade = "A"; var enrollmentNumber = 20;
        
        var student = new Student();
        var course = new Course() { Name = courseName };
        student.Enroll(new Course(), Grade.A);
        
        var command = new StudentTransferCommand { Id = id, Course = courseName, Grade = grade, EnrollmentNumber = enrollmentNumber };

        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.From(student));
        _unitOfWork.Setup(u => u.Courses.GetByName(courseName)).ReturnsAsync(Maybe.From(course));

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("No enrollment found with number");
    }
    
    [Fact]
    public async Task Handle_Succeeds_ReturnsSuccessResult()
    {
        // arrange
        var id = Guid.NewGuid(); var courseName = "math"; var grade = "A"; var enrollmentNumber = 0;
        var student = new Student();
        var course = new Course { Name = courseName };
        
        student.Enroll(new Course(), Grade.A);
        
        var command = new StudentTransferCommand { Id = id, Course = courseName, Grade = grade, EnrollmentNumber = enrollmentNumber };

        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.From(student));
        _unitOfWork.Setup(u => u.Courses.GetByName(courseName)).ReturnsAsync(Maybe.From(course));

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsSuccess.Should().Be(true);
        
        _unitOfWork.Verify(u => u.Courses.GetByName(It.IsAny<string>()), Times.Once);
        _unitOfWork.Verify(u => u.CommitAsync(), Times.Once);
    }
}