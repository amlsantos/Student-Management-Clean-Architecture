using Api.Courses;
using Api.Courses.Requests;
using Api.Utils;
using Application.Courses.Commands.Create;
using Application.Courses.Queries.ById;
using Application.Courses.Queries.ByName;
using Application.Courses.Queries.GetAll;
using CSharpFunctionalExtensions;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Test;

public class CoursesControllerTests
{
    private readonly Mock<IMediator> _mediator;
    private readonly CoursesController _controller;

    public CoursesControllerTests()
    {
        _mediator = new Mock<IMediator>();
        _controller = new CoursesController(_mediator.Object);
    }

    [Fact]
    public async Task GetAll_Succeeds_ReturnsAllCourses()
    {
        // arrange
        var expected = new List<GetCoursesResponse>() { new() };
        _mediator.Setup(m => m.Send(It.IsAny<GetCoursesQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(expected);

        // act
        var result = await _controller.GetAll();
        var actual = (result as OkObjectResult).Value;

        // assert
        _mediator.Verify(m => m.Send(It.IsAny<GetCoursesQuery>(), It.IsAny<CancellationToken>()), Times.Once);

        result.Should().BeOfType<OkObjectResult>();
        actual.Should().NotBeNull();
        actual.Should().Be(expected);
    }

    [Fact]
    public async Task GetById_FindsCourse_ReturnsOk()
    {
        // arrange
        var id = Guid.NewGuid();
        var expected = Result.Success(new GetCourseByIdResponse { Id = id });

        _mediator
            .Setup(m => m.Send(It.IsAny<GetCourseByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var result = await _controller.GetById(id);
        var actual = (result as OkObjectResult).Value;

        // assert
        _mediator.Verify(m => m.Send(It.IsAny<GetCourseByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);

        result.Should().BeOfType<OkObjectResult>();
        actual.Should().NotBeNull();
        expected.Value.Should().Be(actual);
        expected.IsSuccess.Should().Be(true);
    }

    [Fact]
    public async Task GetById_DoesNotFindCourse_ReturnsBadRequest()
    {
        // arrange
        var id = Guid.NewGuid();
        var expected = Result.Failure<GetCourseByIdResponse>("some error");

        _mediator
            .Setup(m => m.Send(It.IsAny<GetCourseByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var result = await _controller.GetById(id);
        var actual = (result as BadRequestObjectResult).Value as ErrorDetails;

        // assert
        _mediator.Verify(m => m.Send(It.IsAny<GetCourseByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);

        result.Should().BeOfType<BadRequestObjectResult>();
        actual.Should().NotBeNull();
        expected.Error.Should().Be(actual.Message);
        expected.IsFailure.Should().Be(true);
    }
    
    [Fact]
    public async Task GetByName_FindsCourse_ReturnsOk()
    {
        // arrange
        var name = "math";
        var expected = Result.Success(new GetCourseByNameResponse { Name = name });

        _mediator
            .Setup(m => m.Send(It.IsAny<GetCourseByNameQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var result = await _controller.GetByName(name);
        var actual = (result as OkObjectResult).Value;

        // assert
        _mediator.Verify(m => m.Send(It.IsAny<GetCourseByNameQuery>(), It.IsAny<CancellationToken>()), Times.Once);

        result.Should().BeOfType<OkObjectResult>();
        actual.Should().NotBeNull();
        expected.Value.Should().Be(actual);
        expected.IsSuccess.Should().Be(true);
    }
    
    [Fact]
    public async Task GetByName_DoesNotFindCourse_ReturnsBadRequest()
    {
        // arrange
        var name = "math";
        var expected = Result.Failure<GetCourseByNameResponse>("some error");

        _mediator
            .Setup(m => m.Send(It.IsAny<GetCourseByNameQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var result = await _controller.GetByName(name);
        var actual = (result as BadRequestObjectResult).Value as ErrorDetails;

        // assert
        _mediator.Verify(m => m.Send(It.IsAny<GetCourseByNameQuery>(), It.IsAny<CancellationToken>()), Times.Once);

        result.Should().BeOfType<BadRequestObjectResult>();
        actual.Should().NotBeNull();
        expected.Error.Should().Be(actual.Message);
        expected.IsFailure.Should().Be(true);
    }

    [Fact]
    public async Task Create_Succeeds_ReturnsOk()
    {
        // arrange
        var request = new CreateCourseRequest { Name = "new course name", Credits = 15 };
        var expected = Result.Success();
        
        _mediator
            .Setup(m => m.Send(It.IsAny<CreateCourseCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        
        // act
        var result = await _controller.Create(request);
        
        // assert
        _mediator.Verify(m => m.Send(It.IsAny<CreateCourseCommand>(), It.IsAny<CancellationToken>()), 
            Times.Once);

        result.Should().BeOfType<OkResult>();
        expected.IsSuccess.Should().Be(true);
    }
}