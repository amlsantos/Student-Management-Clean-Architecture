using CSharpFunctionalExtensions;
using StudentManagementSystem.Entities;

namespace Application.Interfaces.Persistence;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> GetAll();
    public Task<Maybe<Student>> GetById(Guid id);
    public Task<IEnumerable<Student>> GetStudentsWithCourses(string? enrolledIn, int? numberOfCourses);
    public Task SaveAsync(Student student);
    public Task Delete(Student student);
}