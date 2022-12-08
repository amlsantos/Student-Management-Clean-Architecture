using Bogus;
using StudentManagementSystem.Entities;

namespace Persistence.Database;

public static class SchoolDbInitializer
{
    static SchoolDbInitializer()
    {
        var studentFaker = new Faker<Student>()
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.Name, f => f.Person.FullName)
            .RuleFor(s => s.Email, f => f.Person.Email);
        Students = studentFaker.GenerateBetween(20, 60);
        
        var courseNames = GetCourseNames();
        var courseFaker = new Faker<Course>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.PickRandom(courseNames))
            .RuleFor(c => c.Credits, f => f.Random.Number(30));
        Courses = courseFaker.GenerateBetween(10, 40);
        
        var enrollmentFaker = new Faker<Enrollment>()
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.StudentId, f => f.PickRandom(Students).Id)
            .RuleFor(e => e.CourseId, f => f.PickRandom(Courses).Id)
            .RuleFor(e => e.Grade, f => f.PickRandom<Grade>());
        Enrollments = enrollmentFaker.GenerateBetween(1, 20);
    }

    private static IList<string> GetCourseNames() => new List<string>()
    {
        "BBA- Bachelor of Business Administration",
        "BMS- Bachelor of Management Science",
        "BFA- Bachelor of Fine Arts",
        "BEM- Bachelor of Event Management",
        "Integrated Law Course- BA + LL.B",
        "BJMC- Bachelor of Journalism and Mass Communication",
        "BFD- Bachelor of Fashion Designing",
        "BSW- Bachelor of Social Work",
        "BBS- Bachelor of Business Studies",
        "BTTM- Bachelor of Travel and Tourism Management",
        "Aviation Courses",
        "B.Sc- Interior Design",
        "B.Sc.- Hospitality and Hotel Administration",
        "Bachelor of Design (B. Design)",
        "Bachelor of Performing Arts",
        "BA in History",
        "Aeronautical Engineering",
        "Automobile Engineering",
        "Civil Engineering",
        "Computer Science and Engineering",
        "Biotechnology Engineering",
        "Electrical and Electronics Engineering",
        "Electronics and Communication Engineering",
        "Automation and Robotics",
        "Petroleum Engineering",
        "Instrumentation Engineering",
        "Ceramic Engineering",
        "Chemical Engineering",
        "Structural Engineering",
        "Transportation Engineering",
        "Construction Engineering",
        "Power Engineering",
        "Robotics Engineering",
        "Textile Engineering",
        "Smart Manufacturing & Automation",
    };

    public static IEnumerable<Student> Students { get; }
    public static IEnumerable<Course> Courses { get; }
    public static IEnumerable<Enrollment> Enrollments { get; }
}