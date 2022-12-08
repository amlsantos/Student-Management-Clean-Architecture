using CSharpFunctionalExtensions;
using FluentAssertions;
using StudentManagementSystem.Entities;
using Xunit;

namespace Domain.Test;

public class StudentTests
{
    private Grade _grade = Grade.A;
    private readonly Student _student;
    private Course _course;

    public StudentTests()
    {
        _student = new Student("studnet name", "student@email.com");
        _course = new Course("course name", 15);

        _student.Enroll(_course, _grade);
    }

    [Fact]
    public void UpdateDetails_WithNewName_UpdatesEntity()
    {
        // arrange
        var expected = "new student name";
        
        // act
        _student.UpdateDetails(expected, _student.Email);
        
        // assert
        expected.Should().Be(_student.Name);
    }
    
    [Fact]
    public void UpdateDetails_WithNewEmail_UpdatesEntity()
    {
        // arrange
        var expected = "student@email.com";
        
        // act
        _student.UpdateDetails(_student.Name, expected);
        
        // assert
        expected.Should().Be(_student.Email);
    }

    [Fact]
    public void GetEnrollment_InvalidNumber_ReturnsNone()
    {
        // arrange
        var expected = true;

        // act
        var actual = _student.GetEnrollment(3);

        // assert
        expected.Should().Be(actual.HasNoValue);
    }
    
    [Fact]
    public void GetEnrollment_ValidNumber_ReturnsEnrollment()
    {
        // arrange
        var expected = true;

        // act
        var actual = _student.GetEnrollment(0);

        // assert
        expected.Should().Be(actual.HasValue);
        actual.Value.Course.Should().Be(_course);
        actual.Value.Grade.Should().Be(_grade);
    }

    [Fact]
    public void RemoveEnrollment_Executes_RemovesEnrollmentAndCreatesDisenrollemnt()
    {
        // arrange
        var previousEnrollmentCount = _student.Enrollments.Count;
        var previousDissenrolmentCount = _student.Disenrollments.Count;
        
        var enrollment = _student.FirstEnrollment.Value;
        var comment = $"removing student from course {enrollment.Course.Name}";
        
        // act
        _student.RemoveEnrollment(enrollment, comment);
        
        // assert
        _student.Enrollments.Count.Should().Be(previousEnrollmentCount - 1);
        _student.Disenrollments.Count.Should().Be(previousDissenrolmentCount + 1);
    }

    [Fact]
    public void Enroll_LessThan2Courses_Succeeds()
    {
        // arrange
        var newCourse = new Course("course 2", 20);
        var newGrade = Grade.B;
        
        var previousEnrollmentsCount = _student.Enrollments.Count;
        
        
        var expected = Result.Success();

        // act
        var actual = _student.Enroll(newCourse, newGrade);

        // assert
        expected.Should().Be(actual);
        actual.IsSuccess.Should().Be(true);
        
        _student.Enrollments.Count.Should().Be(previousEnrollmentsCount + 1);
    }
    
    [Fact]
    public void Enroll_MoreThan2Courses_Fails()
    {
        // arrange
        var expected = Result.Failure("Cannot have");

        // act
        _student.Enroll(new Course(), Grade.A);
        var actual = _student.Enroll(new Course(), Grade.C);

        // assert
        expected.Error.Should().ContainAny(actual.Error.Split(" "));
        actual.IsFailure.Should().Be(true);
    }
}