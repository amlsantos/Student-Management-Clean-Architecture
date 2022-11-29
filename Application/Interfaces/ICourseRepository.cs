using StudentManagementSystem.Entities;

namespace Application.Interfaces;

public interface ICourseRepository
{
    public Task<IEnumerable<Course>> GetAll();
    public Task<Course> GetByName(string name);
    public Task Save(Course course);
    public Task Delete(Course course);
}