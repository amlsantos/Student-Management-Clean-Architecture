using StudentManagementSystem.Common;

namespace StudentManagementSystem.Entities;

public class Course  : Entity
{
    public virtual string Name { get; set; }
    public virtual int Credits { get; set; }
}