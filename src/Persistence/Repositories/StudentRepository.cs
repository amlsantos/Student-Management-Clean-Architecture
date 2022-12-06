using Application.Interfaces;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
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

    public async Task<Maybe<Student>> GetById(Guid id)
    {
        var student = await _context
            .Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(s => s.Id == id);

        return Maybe<Student>.From(student);
    }

    public async Task<IEnumerable<Student>> GetStudentsWithCourses(string? enrolledIn, int? numberOfCourses)
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
        
        if (numberOfCourses.HasValue) 
            result = result.Where(x => x.Enrollments.Count == numberOfCourses).ToList();

        return result;
    }

    public async Task SaveAsync(Student student) => await _context.Students.AddAsync(student);

    public Task Delete(Student student)
    {
        _context.Students.Remove(student);
        
        return Task.FromResult(Task.CompletedTask.IsCompleted);
    }
}