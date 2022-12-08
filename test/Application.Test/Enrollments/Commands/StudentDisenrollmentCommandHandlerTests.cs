using Application.Enrollments.Commands.Delete;
using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Enrollments.Commands;

public class StudentDisenrollmentCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly ICommandHandler<StudentDisenrollmentCommand, Result> _handler;
    
    public StudentDisenrollmentCommandHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new StudentDisenrollmentCommandHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_NotValidStudent_ReturnsFailResult()
    {
        // arrange
        var id = Guid.NewGuid(); var command = new StudentDisenrollmentCommand { Id = id };
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.None);
        
        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("No student found");
    }
    
    [Fact]
    public async Task Handle_NotValidComment_ReturnsFailResult()
    {
        // arrange
        var id = Guid.NewGuid(); var comment = string.Empty; 
        var command = new StudentDisenrollmentCommand { Id = id, Comment = comment };
        
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.From(new Student("name", "email@student.com")));

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("Disenrollment comment is required");
    }
    
    [Fact]
    public async Task Handle_NotValidEnrollment_ReturnsFailResult()
    {
        // arrange
        var id = Guid.NewGuid(); var comment = "my comment"; 
        var command = new StudentDisenrollmentCommand { Id = id, Comment = comment };
        
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.From(new Student("name", "email@student.com")));

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("No enrollment found");
    }
    
    [Fact]
    public async Task Handle_Succeeds_ReturnsSuccessResult()
    {
        // arrange
        var id = Guid.NewGuid(); 
        const string comment = "my comment";
        
        var student = new Student("name", "email@student.com"); 
        student.Enroll(new Course("course name", 0), Grade.A);
        
        var command = new StudentDisenrollmentCommand { Id = id, Comment = comment, EnrollmentNumber = 0 };
        
        _unitOfWork.Setup(u => u.Students.GetById(id)).ReturnsAsync(Maybe.From(student));

        // act
        var actual = await _handler.Handle(command, CancellationToken.None);

        // assert
        actual.IsSuccess.Should().Be(true);
        
        _unitOfWork.Verify(u => u.Students.GetById(It.IsAny<Guid>()), Times.Once);
        _unitOfWork.Verify(u => u.CommitAsync(), Times.Once);
    }
}