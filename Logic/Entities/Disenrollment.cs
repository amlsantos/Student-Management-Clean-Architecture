using StudentManagementSystem.Common;

namespace StudentManagementSystem.Entities;

public class Disenrollment: Entity
{
    public Guid StudentId { get; set; }
    public virtual Student Student { get; protected set; }

    public Guid CourseId { get; set; }
    public virtual Course Course { get; protected set; }
    
    public virtual DateTime DateTime { get; protected set; }
    public virtual string Comment { get; protected set; }

    protected Disenrollment() { }

    public Disenrollment(Student student, Course course, string comment) : this()
    {
        Student = student;
        Course = course;
        Comment = comment;
        DateTime = DateTime.UtcNow;
    }
}