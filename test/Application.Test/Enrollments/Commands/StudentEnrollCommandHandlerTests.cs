using Application.Enrollments.Commands.Create;
using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Enrollments.Commands;

public class StudentEnrollCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly ICommandHandler<StudentEnrollCommand, Result> _handler;

    public StudentEnrollCommandHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new StudentEnrollCommandHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_NotValidStudent_ReturnsFailResult()
    {
        // arrange
        var id = Guid.NewGuid();
        var command = new StudentEnrollCommand() { Id = id };
        
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.None);

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("No student found with given Id");
    }
    
    [Fact]
    public async Task Handle_NotValidCourse_ReturnsFailResult()
    {
        // arrange
        var id = Guid.NewGuid(); var name = "course name";
        var command = new StudentEnrollCommand() { Id = id, Course = name };
       
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.From(new Student("name", "email@student.com")));
        _unitOfWork.Setup(u => u.Courses.GetByName(name)).ReturnsAsync(Maybe.None);

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("Course is incorrect");
    }
    
    [Fact]
    public async Task Handle_NotValidGrade_ReturnsFailResult()
    {
        // arrange
        var id = Guid.NewGuid(); var name = "course name"; var grade = "aa";
        var command = new StudentEnrollCommand() { Id = id, Course = name , Grade = grade };
       
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.From(new Student("name", "email@student.com")));
        _unitOfWork.Setup(u => u.Courses.GetByName(name)).ReturnsAsync(Maybe.From(new Course("course name", 0)));

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("Grade is incorrect");
    }

    [Fact]
    public async Task Handle_Succeeds_ReturnsSuccessResult()
    {
        // arrange
        var id = Guid.NewGuid(); var name = "course name"; var grade = "A";
        var command = new StudentEnrollCommand() { Id = id, Course = name , Grade = grade };
        
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.From(new Student("name", "email@student.com")));
        _unitOfWork.Setup(u => u.Courses.GetByName(name)).ReturnsAsync(Maybe.From(new Course("course name", 0)));
        _unitOfWork.Setup(u => u.CommitAsync());
        
        // act
        var actual = await _handler.Handle(command, CancellationToken.None);
        
        // assert
        _unitOfWork.Verify(u => u.Students.GetById(It.IsAny<Guid>()), Times.Once);
        _unitOfWork.Verify(u => u.Courses.GetByName(It.IsAny<string>()), Times.Once);
        _unitOfWork.Verify(u => u.CommitAsync(), Times.Once);
        
        actual.IsSuccess.Should().Be(true);
    }
}