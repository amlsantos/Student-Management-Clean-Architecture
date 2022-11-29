using StudentManagementSystem.Common;

namespace StudentManagementSystem.Entities;

public class Enrollment : Entity
{
    public Guid StudentId { get; set; }
    public virtual Student Student { get; protected set; }

    public Guid CourseId { get; set; }
    public virtual Course Course { get; protected set; }
    public virtual Grade Grade { get; set; }
    
    public Enrollment() { }

    public Enrollment(Student student, Course course, Grade grade)
        : this()
    {
        StudentId = student.Id;
        Student = student;
        
        Course = course;
        
        Grade = grade;
    }

    public virtual void Update(Course course, Grade grade)
    {
        Course = course;
        Grade = grade;
    }
}