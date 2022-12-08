using Api.Students;
using Api.Students.Requests;
using Api.Utils;
using Application.Enrollments.Commands.Create;
using Application.Enrollments.Commands.Delete;
using Application.Enrollments.Commands.Update;
using Application.Students.Commands.Create;
using Application.Students.Commands.Delete;
using Application.Students.Commands.Update;
using Application.Students.Queries.GetAll;
using CSharpFunctionalExtensions;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Test;

public class StudentsControllerTests
{
    private readonly Mock<IMediator> _mediator;
    private readonly StudentsController _controller;

    public StudentsControllerTests()
    {
        _mediator = new Mock<IMediator>();
        _controller = new StudentsController(_mediator.Object);
    }

    [Fact]
    public async Task GetList_Succeeds_ReturnsExistingStudents()
    {
        // arrange
        var enrolledIn = "math"; var number = 2;
        var expected = new List<GetStudentsResponse>() { new() };

        _mediator
            .Setup(m => m.Send(It.IsAny<GetStudentsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var result = await _controller.GetList(enrolledIn, number);
        var actual = result as OkObjectResult;
        
        // assert
        _mediator.Verify(m => m.Send(It.IsAny<GetStudentsQuery>(), It.IsAny<CancellationToken>()), 
            Times.Once);

        result.Should().BeOfType<OkObjectResult>();
        actual.Should().NotBeNull();
        expected.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Register_Succeeds_ReturnsOk()
    {
        // arrange
        var request = new RegisterStudentRequest();
        var expected = Result.Success();
        
        _mediator
            .Setup(m => m.Send(It.IsAny<RegisterStudentCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var result = await _controller.Register(request);

        // assert
        _mediator.Verify(m => m.Send(It.IsAny<RegisterStudentCommand>(), It.IsAny<CancellationToken>()), 
            Times.Once);
        
        result.Should().BeOfType<OkResult>();
    }
    
    [Fact]
    public async Task Register_Fails_ReturnsBadRequest()
    {
        // arrange
        var request = new RegisterStudentRequest();
        var expected = Result.Failure("some error");
        
        _mediator
            .Setup(m => m.Send(It.IsAny<RegisterStudentCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var result = await _controller.Register(request);
        var actual = (result as BadRequestObjectResult).Value as ErrorDetails;

        // assert
        _mediator.Verify(m => m.Send(It.IsAny<RegisterStudentCommand>(), It.IsAny<CancellationToken>()), 
            Times.Once);
        
        result.Should().BeOfType<BadRequestObjectResult>();
        actual.Should().NotBeNull();
        expected.Error.Should().Be(actual.Message);
        expected.IsFailure.Should().Be(true);
    }

    [Fact]
    public async Task Unregister_Succeeds_ReturnsOk()
    {
        // arrange
        var id = Guid.NewGuid();
        var expected = Result.Success<string>("success");

        _mediator
            .Setup(m => m.Send(It.IsAny<UnregisterStudentCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        
        // act
        var result = await _controller.Unregister(id);
        var actual = result as OkObjectResult;
        
        // assert
        _mediator.Verify(m => m.Send(It.IsAny<UnregisterStudentCommand>(), It.IsAny<CancellationToken>()), 
            Times.Once);
        
        result.Should().BeOfType<OkObjectResult>();
        actual.Should().NotBeNull();
        
        expected.IsSuccess.Should().Be(true);
        expected.Should().NotBeNull();
    }
    
    [Fact]
    public async Task Unregister_Fails_ReturnsBadRequest()
    {
        // arrange
        var id = Guid.NewGuid();
        var expected = Result.Failure<string>("some error");

        _mediator
            .Setup(m => m.Send(It.IsAny<UnregisterStudentCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        
        // act
        var result = await _controller.Unregister(id);
        var actual = (result as BadRequestObjectResult).Value as ErrorDetails;
        
        // assert
        _mediator.Verify(m => m.Send(It.IsAny<UnregisterStudentCommand>(), It.IsAny<CancellationToken>()), 
            Times.Once);
        
        result.Should().BeOfType<BadRequestObjectResult>();
        actual.Should().NotBeNull();
        
        expected.IsFailure.Should().Be(true);
        expected.Should().NotBeNull();
        expected.Error.Should().Be(actual.Message);
    }

    [Fact]
    public async Task Enroll_Succeeds_ReturnsOk()
    {
        // arrange
        var id = Guid.NewGuid(); var request = new StudentEnrollmentRequest();
        var expected = Result.Success();

        _mediator
            .Setup(m => m.Send(It.IsAny<StudentEnrollCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        
        // act
        var result = await _controller.Enroll(id, request);
        
        // assert
        _mediator.Verify(m => m.Send(It.IsAny<StudentEnrollCommand>(), It.IsAny<CancellationToken>()), 
            Times.Once);
        
        result.Should().BeOfType<OkResult>();
        expected.IsSuccess.Should().Be(true);
        expected.Should().NotBeNull();
    }
    
    [Fact]
    public async Task Enroll_Fails_ReturnsBadRequest()
    {
        var id = Guid.NewGuid(); var request = new StudentEnrollmentRequest();
        var expected = Result.Failure("some error");

        _mediator
            .Setup(m => m.Send(It.IsAny<StudentEnrollCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        
        // act
        var result = await _controller.Enroll(id, request);
        var actual = (result as BadRequestObjectResult).Value as ErrorDetails;
        
        // assert
        _mediator.Verify(m => m.Send(It.IsAny<StudentEnrollCommand>(), It.IsAny<CancellationToken>()), 
            Times.Once);
        
        result.Should().BeOfType<BadRequestObjectResult>();
        expected.IsFailure.Should().Be(true);
        expected.Should().NotBeNull();
        expected.Error.Should().Be(actual.Message);
    }

    [Fact]
    public async Task Transfer_Succeeds_ReturnsOk()
    {
        // arrange
        var id = Guid.NewGuid(); var enrollmentNumber = 2; var request = new StudentTransferRequest();
        var expected = Result.Success();

        _mediator
            .Setup(m => m.Send(It.IsAny<StudentTransferCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var result = await _controller.Transfer(id, enrollmentNumber, request);

        // assert
        _mediator
            .Verify(m => m.Send(It.IsAny<StudentTransferCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        
        result.Should().BeOfType<OkResult>();
        expected.IsSuccess.Should().Be(true);
    }
    
    [Fact]
    public async Task Transfer_Fails_ReturnsBadRequest()
    {
        // arrange
        var id = Guid.NewGuid(); var enrollmentNumber = 2; var request = new StudentTransferRequest();
        var expected = Result.Failure("some error");
        
        _mediator
            .Setup(m => m.Send(It.IsAny<StudentTransferCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        
        // act
        var result = await _controller.Transfer(id, enrollmentNumber, request);
        var actual = (result as BadRequestObjectResult).Value as ErrorDetails;
        
        // assert
        _mediator
            .Verify(m => m.Send(It.IsAny<StudentTransferCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        
        result.Should().BeOfType<BadRequestObjectResult>();
        expected.IsFailure.Should().Be(true);
        expected.Error.Should().Be(actual.Message);
    }
    
    [Fact]
    public async Task Disenroll_Succeeds_ReturnsOk()
    {
        // arrange
        var id = Guid.NewGuid(); var enrollmentNumber = 2; var request = new StudentDisenrollmentRequest();
        var expected = Result.Success();
        
        _mediator
            .Setup(m => m.Send(It.IsAny<StudentDisenrollmentCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        
        // act
        var result = await _controller.Disenroll(id, enrollmentNumber, request);

        // assert
        _mediator
            .Verify(m => m.Send(It.IsAny<StudentDisenrollmentCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        
        result.Should().BeOfType<OkResult>();
        expected.IsSuccess.Should().Be(true);
    }
    
    [Fact]
    public async Task Disenroll_Fails_ReturnsBadRequest()
    {
        // arrange
        var id = Guid.NewGuid(); var enrollmentNumber = 2; var request = new StudentDisenrollmentRequest();
        var expected = Result.Failure("some error");
        
        _mediator
            .Setup(m => m.Send(It.IsAny<StudentDisenrollmentCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        
        // act
        var result = await _controller.Disenroll(id, enrollmentNumber, request);
        var actual = (result as BadRequestObjectResult).Value as ErrorDetails;

        // assert
        _mediator
            .Verify(m => m.Send(It.IsAny<StudentDisenrollmentCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        
        result.Should().BeOfType<BadRequestObjectResult>();
        expected.IsFailure.Should().Be(true);
        expected.Error.Should().Be(actual.Message);
    }
    
    [Fact]
    public async Task EditPersonalInfo_Succeeds_ReturnsOk()
    {
        // arrange
        var id = Guid.NewGuid(); var request = new EditStudentPersonalInfoRequest();
        var expected = Result.Success();
        
        _mediator
            .Setup(m => m.Send(It.IsAny<EditStudentCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        
        // act
        var result = await _controller.EditPersonalInfo(id, request);

        // assert
        _mediator
            .Verify(m => m.Send(It.IsAny<EditStudentCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        
        result.Should().BeOfType<OkResult>();
        expected.IsSuccess.Should().Be(true);
    }
    
    [Fact]
    public async Task EditPersonalInfo_Fails_ReturnsBadRequest()
    {
        // arrange
        var id = Guid.NewGuid(); var request = new EditStudentPersonalInfoRequest();
        var expected = Result.Failure("some error");
        
        _mediator
            .Setup(m => m.Send(It.IsAny<EditStudentCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        
        // act
        var result = await _controller.EditPersonalInfo(id, request);
        var actual = (result as BadRequestObjectResult).Value as ErrorDetails;

        // assert
        _mediator
            .Verify(m => m.Send(It.IsAny<EditStudentCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        
        result.Should().BeOfType<BadRequestObjectResult>();
        expected.IsFailure.Should().Be(true);
        expected.Error.Should().Be(actual.Message);
    }
}