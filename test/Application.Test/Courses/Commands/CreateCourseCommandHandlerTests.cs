using Application.Courses.Commands.Create;
using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Courses.Commands;

public class CreateCourseCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly ICommandHandler<CreateCourseCommand, Result> _handler;

    public CreateCourseCommandHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreateCourseCommandHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_Succeeds_ReturnsResult()
    {
        // arrange
        var command = new CreateCourseCommand();
        _unitOfWork.Setup(u => u.Courses.AddAsync(It.IsAny<Course>()));

        // act
        var result = await _handler.Handle(command, CancellationToken.None);

        // assert
        result.IsSuccess.Should().Be(true);
        
        _unitOfWork.Verify(u => u.Courses.AddAsync(It.IsAny<Course>()), Times.Once);
        _unitOfWork.Verify(u => u.CommitAsync(), Times.Once);
    }
}