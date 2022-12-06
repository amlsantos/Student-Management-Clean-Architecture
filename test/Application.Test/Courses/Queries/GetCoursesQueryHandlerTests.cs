using Application.Contracts;
using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using Application.UseCases.Courses.Queries.GetAll;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Courses.Queries;

public class GetCoursesQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly IQueryHandler<GetCoursesQuery, List<GetCoursesResponse>> _handler;

    public GetCoursesQueryHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new GetCoursesQueryHandler(_unitOfWork.Object);
    }
    
    [Fact]
    public async Task Handle_Succeeds_ReturnsAllCourses()
    {
        // arrange
        var query = new GetCoursesQuery();
        _unitOfWork.Setup(u => u.Courses.GetAll()).ReturnsAsync(new List<Course> { new() });

        // act
        var actual = await _handler.Handle(query, CancellationToken.None);

        // assert
        actual.Should().NotBeNullOrEmpty();
    }
}