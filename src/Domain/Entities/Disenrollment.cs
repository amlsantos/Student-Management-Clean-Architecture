using CSharpFunctionalExtensions;

namespace StudentManagementSystem.Entities;

public sealed class Disenrollment : Entity<Guid>
{
    public override Guid Id { get; protected set; }
    public Guid StudentId { get; init; }
    public Student Student { get; }

    public Guid CourseId { get; init; }
    public Course Course { get; }
    public DateTime DateTime { get; }
    public string Comment { get; }

    public Disenrollment() { }
    public Disenrollment(Student student, Course course, string comment) : this()
    {
        Student = student;
        Course = course;
        Comment = comment;
        DateTime = DateTime.UtcNow;
    }
}