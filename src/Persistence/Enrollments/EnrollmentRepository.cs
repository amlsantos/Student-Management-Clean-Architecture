using Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using StudentManagementSystem.Entities;

namespace Persistence.Enrollments;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly SchoolDbContext _context;

    public EnrollmentRepository(SchoolDbContext context) => _context = context;

    public async Task<IEnumerable<Enrollment>> GetAll()
    {
        return await _context.Enrollments
            .Include(e => e.Course)
            .Include(e => e.Student)
            .ToListAsync();
    }

    public async Task Save(Enrollment enrollment) => await _context.Enrollments.AddAsync(enrollment);

    public Task Delete(Enrollment enrollment)
    {
        _context.Enrollments.Remove(enrollment);
        
        return Task.FromResult(Task.CompletedTask.IsCompleted);
    }
}