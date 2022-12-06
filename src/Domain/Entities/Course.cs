using StudentManagementSystem.Common;

namespace StudentManagementSystem.Entities;

public class Course  : Entity
{
    public Course() { }
    
    public Course(string name, int credits)
    {
        Name = name;
        Credits = credits;
    }

    public virtual string Name { get; set; }
    public virtual int Credits { get; set; }
}