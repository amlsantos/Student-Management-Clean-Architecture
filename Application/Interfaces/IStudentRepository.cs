using StudentManagementSystem.Entities;

namespace Application.Interfaces;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> GetAll();
    public Task<Student> GetById(Guid id);
    public Task<IEnumerable<Student>> GetList(string enrolledIn, int? numberOfCourses);
    public Task SaveAsync(Student student);
    public Task Delete(Student student);
}