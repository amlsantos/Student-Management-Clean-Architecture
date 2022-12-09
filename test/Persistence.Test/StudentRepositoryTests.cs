using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Persistence.Database;
using Persistence.Students;
using StudentManagementSystem.Entities;
using Xunit;

namespace Persistence.Test;

public class StudentRepositoryTests
{
    private readonly IQueryable<Student> _students;
    private readonly IQueryable<Enrollment> _enrollments;
    private readonly Mock<DbSet<Student>> _studentDbSetMock;
    private readonly Mock<DbSet<Enrollment>> _enrollmentDbSetMock;
    private readonly Mock<SchoolDbContext> _contextMock;
    private readonly IStudentRepository _repository;
    
    public StudentRepositoryTests()
    {
        _students = SchoolDbInitializer.Students.AsQueryable();
        _enrollments = SchoolDbInitializer.Enrollments.AsQueryable();
        
        _studentDbSetMock = _students.BuildMockDbSet();
        _enrollmentDbSetMock = _enrollments.BuildMockDbSet();
        
        _contextMock = new Mock<SchoolDbContext>();
        _repository = new StudentRepository(_contextMock.Object);
    }
    
    [Fact]
    public async Task GetAll_ReturnsAllStudents()
    {
        // arrange
        _contextMock.Setup(c => c.Students).Returns(_studentDbSetMock.Object);

        // act
        var actual = await _repository.GetAll();

        // assert
        actual.Count().Should().BePositive();
        actual.Should().NotBeNull();
    }

    [Fact]
    public async Task GetById_FindsStudentWithId_ReturnsExistingStudent()
    {
        // arrange
        _contextMock.Setup(c => c.Students).Returns(_studentDbSetMock.Object);
        var student = SchoolDbInitializer.Students.ElementAt(0);
        var expected = Maybe.From(student);
        
        // act
        var actual = await _repository.GetById(student.Id);
        
        // arrange
        actual.HasValue.Should().Be(true);
        actual.Value.Should().NotBeNull();
        expected.Value.Id.Should().Be(actual.Value.Id);
    }
    
    [Fact]
    public async Task GetById_DoesNotFindsStudentWithId_ReturnsNone()
    {
        // arrange
        _contextMock.Setup(c => c.Students).Returns(_studentDbSetMock.Object);
        var expected = Maybe<Student>.From(null);
        
        // act
        var actual = await _repository.GetById(Guid.Empty);
        
        // arrange
        actual.HasNoValue.Should().Be(true);
        expected.HasNoValue.Should().Be(actual.HasNoValue);
    }

    [Fact]
    public async Task GetStudentsWithCourses_ValidCourseName_ReturnsStudentsEnrolledOnThatCourse()
    {
        // arrange
        var enrollment = _enrollments.ElementAt(0);
        var studentId = enrollment.StudentId;
        var student = _students.FirstOrDefault(s => s.Id == studentId);
        
        var courseId = enrollment.CourseId;
        var course = SchoolDbInitializer.Courses.FirstOrDefault(c => c.Id == courseId);
        
        _contextMock.Setup(c => c.Students).Returns(_studentDbSetMock.Object);
        _contextMock.Setup(c => c.Enrollments).Returns(_enrollmentDbSetMock.Object);
    }
}