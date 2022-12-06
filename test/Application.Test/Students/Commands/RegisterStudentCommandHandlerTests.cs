using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using Application.UseCases.Students.Commands.Create;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Students.Commands;

public class RegisterStudentCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly ICommandHandler<RegisterStudentCommand, Result> _handler;
    
    public RegisterStudentCommandHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new RegisterStudentCommandHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_InvalidCourse_ReturnsFailResult()
    {
        // arrange
        const string courseName = "chinese";
        var command = new RegisterStudentCommand();
        
        _unitOfWork.Setup(u => u.Courses.GetByName(courseName)).ReturnsAsync(Maybe<Course>.None);

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("There is no course for the given name");
    }
    
    [Fact]
    public async Task Handle_InvalidGrade_ReturnsFailResult()
    {
        // arrange
        var course = new Course("math", 20);
        var command = new RegisterStudentCommand { Name = "student name", Email = "student@email.com", Course1Grade = "QQ", Course2Grade = "CC" };
        
        _unitOfWork.Setup(u => u.Courses.GetByName(It.IsAny<string>())).ReturnsAsync(Maybe.From(course));

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("Grade is incorrect");
    }

    [Fact]
    public async Task Handle_CorrectData_ReturnsSuccessResult()
    {
        // arrange
        var course = new Course("math", 20);
        var command = new RegisterStudentCommand { Name = "student name", Email = "student@email.com", Course1Grade = "A", Course2Grade = "B" };
        
        _unitOfWork.Setup(u => u.Courses.GetByName(It.IsAny<string>())).ReturnsAsync(Maybe.From(course));
        _unitOfWork.Setup(u => u.Students.SaveAsync(It.IsAny<Student>()));

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsSuccess.Should().Be(true);
        
        _unitOfWork.Verify(u => u.Courses.GetByName(It.IsAny<string>()), Times.Exactly(2));
        _unitOfWork.Verify(u => u.Students.SaveAsync(It.IsAny<Student>()), Times.Once());
        _unitOfWork.Verify(u => u.CommitAsync(), Times.Once());
    }
}