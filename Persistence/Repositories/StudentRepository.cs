using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using StudentManagementSystem.Entities;

namespace Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext _context;

    public StudentRepository(StudentDbContext context) => _context = context;

    public async Task<IEnumerable<Student>> GetAll()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student> GetById(Guid id) => await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

    public async Task<IEnumerable<Student>> GetList(string enrolledIn, int? numberOfCourses)
    {
        var enrollments = await _context.Enrollments
            .Include(e => e.Course)
            .Include(e => e.Student)
            .ToListAsync();

        if (!string.IsNullOrWhiteSpace(enrolledIn))
        {
            enrollments = enrollments
                .Where(e => string.Equals(e.Course.Name, enrolledIn, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        var result = enrollments.Select(e => e.Student).ToList();
        if (numberOfCourses != null)
        {
            result = result.Where(x => x.Enrollments.Count == numberOfCourses).ToList();
        }

        return result;
    }

    public async Task SaveAsync(Student student) => await _context.Students.AddAsync(student);

    public Task Delete(Student student)
    {
        _context.Students.Remove(student);
        
        return Task.FromResult(Task.CompletedTask.IsCompleted);
    }
}