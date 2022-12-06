using CSharpFunctionalExtensions;
using Entity = StudentManagementSystem.Common.Entity;

namespace StudentManagementSystem.Entities;

public class Student : Entity
{
    public virtual string Name { get; set; }
    public virtual string Email { get; set; }

    private readonly IList<Enrollment> _enrollments = new List<Enrollment>();
    public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();
    
    public virtual Maybe<Enrollment> FirstEnrollment => GetEnrollment(0);
    public virtual Maybe<Enrollment> SecondEnrollment => GetEnrollment(1);

    private readonly IList<Disenrollment> _disenrollments = new List<Disenrollment>();
    public virtual IReadOnlyList<Disenrollment> Disenrollments => _disenrollments.ToList();

    public Student() { }

    public Student(string name, string email) : this()
    {
        Name = name;
        Email = email;
    }

    public Maybe<Enrollment> GetEnrollment(int index)
    {
        if (_enrollments.Count > index)
            return Maybe<Enrollment>.From(_enrollments[index]);

        return Maybe<Enrollment>.None;
    }

    public virtual void RemoveEnrollment(Enrollment enrollment, string comment)
    {
        _enrollments.Remove(enrollment);
        CreateDisenrollment(enrollment, comment);
    }

    public virtual void CreateDisenrollment(Enrollment enrollment, string comment)
    {
        _disenrollments.Add(
            new Disenrollment(enrollment.Student, enrollment.Course, comment));
    }

    public virtual void Enroll(Course course, Grade grade)
    {
        if (_enrollments.Count >= 2)
            throw new Exception("Cannot have more than 2 enrollments");

        var enrollment = new Enrollment(this, course, grade);
        _enrollments.Add(enrollment);
    }
}