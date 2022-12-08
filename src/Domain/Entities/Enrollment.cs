using CSharpFunctionalExtensions;

namespace StudentManagementSystem.Entities;

public sealed class Enrollment : Entity<Guid>
{
    public override Guid Id { get; protected set; }
    public Guid StudentId { get; init; }
    public Student Student { get; }
    public Guid CourseId { get; init; }
    public Course Course { get; private set; }
    public Grade Grade { get; set; }

    public Enrollment() { }
    public Enrollment(Student student, Course course, Grade grade) : this()
    {
        StudentId = student.Id;
        Student = student;
        CourseId = course.Id;
        Course = course;
        Grade = grade;
    }

    public void Update(Course course, Grade grade)
    {
        Course = course;
        Grade = grade;
    }
}