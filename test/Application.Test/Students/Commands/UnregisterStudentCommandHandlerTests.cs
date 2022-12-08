using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using Application.Students.Commands.Delete;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Students.Commands;

public class UnregisterStudentCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly ICommandHandler<UnregisterStudentCommand, Result<string>> _handler;

    public UnregisterStudentCommandHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new UnregisterStudentCommandHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_InvalidStudentId_ReturnsFailureResult()
    {
        // arrange
        var request = new UnregisterStudentCommand { Id = Guid.NewGuid() };
        _unitOfWork.Setup(u => u.Students.GetById(It.IsAny<Guid>())).ReturnsAsync(Maybe.None);
        
        // act
        var actual = await _handler.Handle(request, CancellationToken.None);
        
        // assert
        actual.IsFailure.Should().Be(true);
        actual.Error.Should().Contain($"No student found for Id {request.Id}");
        
        _unitOfWork.Verify(u => u.Students.GetById(It.IsAny<Guid>()), Times.Once);
        _unitOfWork.Verify(u => u.Students.Delete(It.IsAny<Student>()), Times.Never());
        _unitOfWork.Verify(u => u.CommitAsync(), Times.Never());
    }
    
    [Fact]
    public async Task Handle_ValidStudentId_ReturnsSuccessResult()
    {
        // arrange
        var request = new UnregisterStudentCommand();
        _unitOfWork.Setup(u => u.Students.GetById(It.IsAny<Guid>())).ReturnsAsync(Maybe.From(new Student()));
        
        // act
        var actual = await _handler.Handle(request, CancellationToken.None);
        
        // assert
        actual.IsSuccess.Should().Be(true);
        
        _unitOfWork.Verify(u => u.Students.GetById(It.IsAny<Guid>()), Times.Once);
        _unitOfWork.Verify(u => u.Students.Delete(It.IsAny<Student>()), Times.Once);
        _unitOfWork.Verify(u => u.CommitAsync(), Times.Once);
    }
}