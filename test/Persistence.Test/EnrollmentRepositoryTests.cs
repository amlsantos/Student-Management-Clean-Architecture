using Application.Interfaces.Persistence;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Persistence.Database;
using Persistence.Enrollments;
using StudentManagementSystem.Entities;
using Xunit;

namespace Persistence.Test;

public class EnrollmentRepositoryTests
{
    private readonly IQueryable<Enrollment> _enrollments;
    private readonly Mock<DbSet<Enrollment>> _dbSetMock;
    private readonly Mock<SchoolDbContext> _contextMock;
    private readonly IEnrollmentRepository _repository;
    
    public EnrollmentRepositoryTests()
    {
        _enrollments = SchoolDbInitializer.Enrollments.AsQueryable();
        _dbSetMock = _enrollments.BuildMockDbSet();
        _contextMock = new Mock<SchoolDbContext>();
        _repository = new EnrollmentRepository(_contextMock.Object);
    }
    
    [Fact]
    public async Task GetAll_ReturnsAllEnrollments()
    {
        // arrange
        _contextMock.Setup(c => c.Enrollments).Returns(_dbSetMock.Object);

        // act
        var actual = await _repository.GetAll();

        // assert
        actual.Count().Should().BePositive();
        actual.Should().NotBeNull();
    }
}