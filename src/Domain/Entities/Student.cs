using CSharpFunctionalExtensions;

namespace StudentManagementSystem.Entities;

public sealed class Student : Entity<Guid>
{
    public override Guid Id { get; protected set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    private readonly IList<Enrollment> _enrollments = new List<Enrollment>();
    public IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();
    
    public Maybe<Enrollment> FirstEnrollment => GetEnrollment(0);
    public Maybe<Enrollment> SecondEnrollment => GetEnrollment(1);
    
    private readonly IList<Disenrollment> _disenrollments = new List<Disenrollment>();
    public IReadOnlyList<Disenrollment> Disenrollments => _disenrollments.ToList();

    public Student() { }
    public Student(string name, string email) : this()
    {
        Name = name;
        Email = email;
    }

    public void UpdateDetails(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public Maybe<Enrollment> GetEnrollment(int index)
    {
        return _enrollments.Count > index ? 
            Maybe.From(_enrollments[index]) : 
            Maybe.None;
    }

    public void RemoveEnrollment(Enrollment enrollment, string comment)
    {
        _enrollments.Remove(enrollment);
        
        CreateDisenrollment(enrollment, comment);
    }

    private void CreateDisenrollment(Enrollment enrollment, string comment)
    {
        _disenrollments.Add(
            new Disenrollment(enrollment.Student, enrollment.Course, comment));
    }

    public Result Enroll(Course course, Grade grade)
    {
        if (_enrollments.Count >= 2)
            return Result.Failure("Cannot have more than 2 enrollments");

        var enrollment = new Enrollment(this, course, grade);
        _enrollments.Add(enrollment);
        
        return Result.Success();
    }
}