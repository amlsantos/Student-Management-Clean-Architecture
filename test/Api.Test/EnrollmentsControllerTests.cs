using Api.Controllers;
using Application.Contracts;
using Application.UseCases.Courses.Queries.GetAll;
using Application.UseCases.Enrollments.Queries.GetAll;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Test;

public class EnrollmentsControllerTests
{
    private readonly Mock<IMediator> _mediator;
    private readonly EnrollmentsController _controller;

    public EnrollmentsControllerTests()
    {
        _mediator = new Mock<IMediator>();
        _controller = new EnrollmentsController(_mediator.Object);
    }
    
    [Fact]
    public async Task GetAll_Succeeds_ReturnsAllEnrollments()
    {
        // arrange
        var expected = new List<GetEnrollmentsResponse> { new() };
        _mediator.Setup(m => m.Send(It.IsAny<GetEnrollmentsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(expected);

        // act
        var result = await _controller.GetAll();
        var actual = (result as OkObjectResult).Value;

        // assert
        _mediator.Verify(m => m.Send(It.IsAny<GetEnrollmentsQuery>(), It.IsAny<CancellationToken>()), 
            Times.Once);

        result.Should().BeOfType<OkObjectResult>();
        actual.Should().NotBeNull();
        actual.Should().Be(expected);
    }
}