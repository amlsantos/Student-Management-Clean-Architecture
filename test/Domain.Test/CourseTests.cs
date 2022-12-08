using FluentAssertions;
using StudentManagementSystem.Entities;
using Xunit;

namespace Domain.Test;

public class CourseTests
{
    private readonly Course _course;
    
    public CourseTests()
    {
        _course = new Course("course name", 15);
    }

    [Fact]
    public void SetAndGetName_UpdatesEntity()
    {
        // arrange
        var expected = "new course name";
        
        // act
        _course.Update(expected, _course.Credits);

        // assert
        expected.Should().Be(_course.Name);
    }
    
    [Fact]
    public void SetAndGetCredits_UpdatesEntity()
    {
        // arrange
        var expected = 15;
        
        // act
        _course.Update(_course.Name, expected);

        // assert
        expected.Should().Be(_course.Credits);
    }
}