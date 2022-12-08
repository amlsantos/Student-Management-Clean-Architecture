using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using Application.Students.Commands.Update;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Students.Commands;

public class EditStudentCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly ICommandHandler<EditStudentCommand, Result> _handler;

    public EditStudentCommandHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new EditStudentCommandHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_InvalidStudentId_ReturnsFailureResult()
    {
        // arrange
        var request = new EditStudentCommand();
        _unitOfWork.Setup(u => u.Students.GetById(It.IsAny<Guid>())).ReturnsAsync(Maybe<Student>.None);

        // act
        var actual = await _handler.Handle(request, CancellationToken.None);

        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain("No student found for");
        
        _unitOfWork.Verify(u => u.Students.GetById(It.IsAny<Guid>()), Times.Once);
        _unitOfWork.Verify(u => u.CommitAsync(), Times.Never);
    }
    
    [Fact]
    public async Task Handle_ValidStudentId_ReturnsSuccessResult()
    {
        // arrange
        var request = new EditStudentCommand();
        _unitOfWork.Setup(u => u.Students.GetById(It.IsAny<Guid>())).ReturnsAsync(Maybe.From(new Student()));

        // act
        var actual = await _handler.Handle(request, CancellationToken.None);

        // assert
        actual.IsSuccess.Should().Be(true);
        
        _unitOfWork.Verify(u => u.Students.GetById(It.IsAny<Guid>()), Times.Once);
        _unitOfWork.Verify(u => u.CommitAsync(), Times.Once);
    }
}