using CSharpFunctionalExtensions;

namespace StudentManagementSystem.Entities;

public sealed class Course : Entity<Guid>
{
    public override Guid Id { get; protected set; }
    public string Name { get; private set; }
    public int Credits { get; private set; }

    public Course() { }
    public Course(string name, int credits) : this()
    {
        Name = name;
        Credits = credits;
    }

    public void Update(string name, int credits)
    {
        Name = name;
        Credits = credits;
    }
}