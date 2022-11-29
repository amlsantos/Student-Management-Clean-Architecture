using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using StudentManagementSystem.Entities;

namespace Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly StudentDbContext _context;

    public CourseRepository(StudentDbContext context) => _context = context;

    public async Task<IEnumerable<Course>> GetAll() => await _context.Courses.ToListAsync();

    public async Task<Course> GetByName(string name)
    {
        return await _context
            .Courses
            .FirstOrDefaultAsync(
                c => c.Name.ToLower().Contains(name.ToLower()));
    }

    public async Task Save(Course course)
    {
        await _context.Courses.AddAsync(course);
    }

    public Task Delete(Course course)
    {
        _context.Courses.Remove(course);
        
        return Task.FromResult(Task.CompletedTask.IsCompleted);
    }
}