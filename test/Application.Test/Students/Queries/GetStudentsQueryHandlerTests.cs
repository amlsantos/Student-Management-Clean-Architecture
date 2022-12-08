using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using Application.Students.Queries.GetAll;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Students.Queries;

public class GetStudentsQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly IQueryHandler<GetStudentsQuery, List<GetStudentsResponse>> _handler;

    public GetStudentsQueryHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new GetStudentsQueryHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_Succeeds_ReturnsExistingStudents()
    {
        // arrange
        const string enrolledIn = "";
        const int courses = 0;
        var request = new GetStudentsQuery { EnrolledIn = enrolledIn, NumberOfCourses = courses };

        _unitOfWork
            .Setup(u => u.Students.GetStudentsWithCourses(enrolledIn, courses))
            .ReturnsAsync(new List<Student> { new() });

        // act
        var actual = await _handler.Handle(request, CancellationToken.None);

        // assert
        actual.Should().NotBeEmpty();
        actual.Should().NotBeNull();
    }
}