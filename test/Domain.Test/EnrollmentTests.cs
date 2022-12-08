
using FluentAssertions;
using StudentManagementSystem.Entities;
using Xunit;

namespace Domain.Test;

public class EnrollmentTests
{
    private readonly Enrollment _enrollment;

    public EnrollmentTests()
    {
        var student = new Student("student name", "student@email.com");
        var course = new Course("course name", 15);
        
        _enrollment = new Enrollment(student, course, Grade.A);
    }

    [Fact]
    public void GetAndSetStudent_UpdatesEntity()
    {
        // arrange
        var expected = new Student("new student name", "student2@email.com");

        // act
        _enrollment.UpdateStudent(expected);

        // assert
        expected.Should().Be(_enrollment.Student);
    }
    
    [Fact]
    public void GetAndSetCourse_UpdatesEntity()
    {
        // arrange
        var expected = new Course("course name", 10);

        // act
        _enrollment.UpdateCourse(expected, _enrollment.Grade);

        // assert
        expected.Should().Be(_enrollment.Course);
    }
}