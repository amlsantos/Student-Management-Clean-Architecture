using CSharpFunctionalExtensions;
using StudentManagementSystem.Entities;

namespace Application.Interfaces.Persistence;

public interface ICourseRepository
{
    public Task<IEnumerable<Course>> GetAll();
    public Task<Maybe<Course>> GetByName(string name);
    public Task<Maybe<Course>> GetById(Guid id);
    public Task AddAsync(Course course);
    public Task Delete(Course course);
}