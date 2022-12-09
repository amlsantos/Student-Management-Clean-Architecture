using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Persistence.Courses;
using Persistence.Database;
using StudentManagementSystem.Entities;
using Xunit;

namespace Persistence.Test;

public class CourseRepositoryTests
{
    private readonly IQueryable<Course> _courses;
    private readonly Mock<DbSet<Course>> _dbSetMock;
    private readonly Mock<SchoolDbContext> _contextMock;
    private readonly ICourseRepository _repository;
    
    public CourseRepositoryTests()
    {
        _courses = SchoolDbInitializer.Courses.AsQueryable();
        _dbSetMock = _courses.BuildMockDbSet();
        _contextMock = new Mock<SchoolDbContext>();
        _repository = new CourseRepository(_contextMock.Object);
    }
    
    [Fact]
    public async Task GetAll_ReturnsAllCourses()
    {
        // arrange
        _contextMock.Setup(c => c.Courses).Returns(_dbSetMock.Object);

        // act
        var actual = await _repository.GetAll();

        // assert
        actual.Count().Should().BePositive();
        actual.Should().NotBeNull();
    }

    [Fact]
    public async Task GetByName_FindsCourse_ReturnsExistingCourse()
    {
        // arrange
        var course = _courses.ElementAt(0);
        var name = course.Name;
        var expected = Maybe.From(course);
        
        _contextMock.Setup(c => c.Courses).Returns(_dbSetMock.Object);
        
        // act
        var actual = await _repository.GetByName(name);
        
        // assert
        expected.HasValue.Should().Be(actual.HasValue);
        expected.Value.Name.Should().Be(actual.Value.Name);
    }
    
    [Fact]
    public async Task GetByName_DoesNotFindCourse_ReturnsNone()
    {
        // arrange
        var name = Guid.NewGuid().ToString();
        var expected = Maybe.From<Course>(null);

        _contextMock.Setup(c => c.Courses).Returns(_dbSetMock.Object);
        
        // act
        var actual = await _repository.GetByName(name);
        
        // assert
        actual.HasNoValue.Should().Be(true);
        expected.HasNoValue.Should().Be(actual.HasNoValue);
    }

    [Fact]
    public async Task GetById_FindsCourse_ReturnsExistingCourse()
    {
        // arrange
        var course = _courses.ElementAt(0);
        var expected = Maybe.From(course);

        _contextMock.Setup(c => c.Courses).Returns(_dbSetMock.Object);
        
        // act
        var actual = await _repository.GetById(course.Id);
        
        // assert
        actual.HasValue.Should().Be(true);
        expected.Value.Id.Should().Be(actual.Value.Id);
    }
    
    [Fact]
    public async Task GetById_DoesNotFindsCourse_ReturnsNone()
    {
        // arrange
        var expected = Maybe<Course>.From(null);
        _contextMock.Setup(c => c.Courses).Returns(_dbSetMock.Object);
        
        // act
        var actual = await _repository.GetById(Guid.Empty);
        
        // assert
        actual.HasNoValue.Should().Be(true);
        expected.HasNoValue.Should().Be(actual.HasNoValue);
    }
}