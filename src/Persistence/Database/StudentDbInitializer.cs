using StudentManagementSystem.Entities;

namespace Persistence.Database;

public static class StudentDbInitializer
{
    public static readonly IEnumerable<Student> Students = new List<Student>
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "student 1",
            Email = "student1@email.com"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "student 2",
            Email = "student2@email.com"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "student 3",
            Email = "student3@email.com"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "student 4",
            Email = "student4@email.com"
        },
    };

    public static readonly IEnumerable<Course> Courses = new List<Course>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Math",
            Credits = 15
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Science",
            Credits = 13
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Portuguese",
            Credits = 15
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Sport",
            Credits = 10
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Philosophy",
            Credits = 9
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "English",
            Credits = 13
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Politics",
            Credits = 12
        }
    };

    public static readonly IEnumerable<Enrollment> Enrollments = new List<Enrollment>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            StudentId = Students.ElementAt(0).Id,
            CourseId = Courses.ElementAt(0).Id,
            Grade = Grade.A
        },
        new()
        {
            Id = Guid.NewGuid(),
            StudentId = Students.ElementAt(0).Id,
            CourseId = Courses.ElementAt(2).Id,
            Grade = Grade.B
        },
        new()
        {
            Id = Guid.NewGuid(),
            StudentId = Students.ElementAt(1).Id,
            CourseId = Courses.ElementAt(0).Id,
            Grade = Grade.B
        },
        new()
        {
            Id = Guid.NewGuid(),
            StudentId = Students.ElementAt(1).Id,
            CourseId = Courses.ElementAt(2).Id,
            Grade = Grade.C
        },
        new()
        {
            Id = Guid.NewGuid(),
            StudentId = Students.ElementAt(2).Id,
            CourseId = Courses.ElementAt(0).Id,
            Grade = Grade.A
        },
        new()
        {
            Id = Guid.NewGuid(),
            StudentId = Students.ElementAt(2).Id,
            CourseId = Courses.ElementAt(2).Id,
            Grade = Grade.A
        },
        new()
        {
            Id = Guid.NewGuid(),
            StudentId = Students.ElementAt(3).Id,
            CourseId = Courses.ElementAt(0).Id,
            Grade = Grade.D
        },
        new()
        {
            Id = Guid.NewGuid(),
            StudentId = Students.ElementAt(3).Id,
            CourseId = Courses.ElementAt(2).Id,
            Grade = Grade.D
        },
    };
}