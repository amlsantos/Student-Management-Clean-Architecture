using Application.Courses.Queries.ById;
using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Courses.Queries;

public class GetCourseByIdQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly IQueryHandler<GetCourseByIdQuery, Result<GetCourseByIdResponse>> _handler;

    public GetCourseByIdQueryHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new GetCourseByIdQueryHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_FindsCourseAndSucceeds_ReturnsSuccessResult()
    {
        // arrange
        var query = new GetCourseByIdQuery { Id = Guid.NewGuid() };
        _unitOfWork
            .Setup(u => u.Courses.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(Maybe.From(new Course("Course name", 0)));
        
        // act
        var actual = await _handler.Handle(query, CancellationToken.None);
        
        // assert
        actual.IsSuccess.Should().Be(true);
    }
    
    [Fact]
    public async Task Handle_DoesNotFindCourse_ReturnsFailResult()
    {
        // arrange
        var query = new GetCourseByIdQuery { Id = Guid.NewGuid() };
        _unitOfWork
            .Setup(u => u.Courses.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(Maybe.None);
        
        // act
        var actual = await _handler.Handle(query, CancellationToken.None);
        
        // assert
        actual.IsFailure.Should().Be(true);
    }
}