using Application.Courses.Queries.ByName;
using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Courses.Queries;

public class GetCoursesByNameQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly IQueryHandler<GetCourseByNameQuery, Result<GetCourseByNameResponse>> _handler;

    public GetCoursesByNameQueryHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new GetCoursesByNameQueryHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_FindsCourseAndSucceeds_ReturnsSuccessResult()
    {
        // arrange
        var courseName = "course name";
        var query = new GetCourseByNameQuery { Name = courseName };
        _unitOfWork
            .Setup(u => u.Courses.GetByName(It.IsAny<string>()))
            .ReturnsAsync(Maybe.From(new Course(courseName, 0)));
        
        // act
        var actual = await _handler.Handle(query, CancellationToken.None);
        
        // assert
        actual.IsSuccess.Should().Be(true);
        actual.Value.Name.Should().Be(query.Name);
    }
    
    [Fact]
    public async Task Handle_DoesNotFindCourse_ReturnsFailResult()
    {
        // arrange
        var query = new GetCourseByNameQuery { Name = "course name" };
        _unitOfWork
            .Setup(u => u.Courses.GetByName(It.IsAny<string>()))
            .ReturnsAsync(Maybe.None);
        
        // act
        var actual = await _handler.Handle(query, CancellationToken.None);
        
        // assert
        actual.IsFailure.Should().Be(true);
    }
}