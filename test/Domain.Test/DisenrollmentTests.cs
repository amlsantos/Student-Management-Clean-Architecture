using StudentManagementSystem.Entities;
using Xunit;

namespace Domain.Test;

public class DisenrollmentTests
{
    private readonly Disenrollment _disenrollment;

    public DisenrollmentTests()
    {
        var student = new Student("student name", "student@email.com");
        var course = new Course("course name", 15);
        
        _disenrollment = new Disenrollment(student, course, $"removing student: {student.Name} from course: {course.Name}");
    }
}