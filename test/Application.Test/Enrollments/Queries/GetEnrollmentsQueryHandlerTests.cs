using Application.Contracts;
using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using Application.UseCases.Enrollments.Queries.GetAll;
using FluentAssertions;
using Moq;
using StudentManagementSystem.Entities;
using Xunit;

namespace Application.Test.Enrollments.Queries;

public class GetEnrollmentsQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly IQueryHandler<GetEnrollmentsQuery, List<GetEnrollmentsResponse>> _handler;
    
    public GetEnrollmentsQueryHandlerTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new GetEnrollmentsQueryHandler(_unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_Succeeds_ReturnsExistingEnrollments()
    {
        // arrange
        var query = new GetEnrollmentsQuery();
        var enrollment = new Enrollment(new Student(), new Course(), Grade.A);
        _unitOfWork.Setup(u => u.Enrollments.GetAll()).ReturnsAsync(new List<Enrollment>() { enrollment });

        // act
        var actual = await _handler.Handle(query, CancellationToken.None);

        // assert
        actual.Should().NotBeNullOrEmpty();
        _unitOfWork.Verify(u => u.Enrollments.GetAll(), Times.Once);
    }
}