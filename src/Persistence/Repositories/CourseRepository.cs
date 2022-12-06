using Application.Interfaces;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using StudentManagementSystem.Entities;

namespace Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly StudentDbContext _context;

    public CourseRepository(StudentDbContext context) => _context = context;

    public async Task<IEnumerable<Course>> GetAll() => await _context.Courses.ToListAsync();

    public async Task<Maybe<Course>> GetByName(string name)
    {
        var course = await _context
            .Courses
            .FirstOrDefaultAsync(c => c.Name.ToLower().Contains(name.ToLower()));
        
        return Maybe.From<Course>(course);
    }

    public async Task<Maybe<Course>> GetById(Guid id)
    {
        var course = await _context
            .Courses
            .FirstOrDefaultAsync(c => c.Id == id);
        
        return Maybe.From<Course>(course);
    }

    public async Task AddAsync(Course course) => await _context.Courses.AddAsync(course);

    public Task Delete(Course course)
    {
        _context.Courses.Remove(course);
        
        return Task.FromResult(Task.CompletedTask.IsCompleted);
    }
}