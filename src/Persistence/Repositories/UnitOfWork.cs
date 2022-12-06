using Application.Interfaces;
using Application.Interfaces.Persistence;
using Persistence.Database;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly StudentDbContext _context;

    public UnitOfWork(StudentDbContext context, IStudentRepository studentRepository, IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository)
    {
        _context = context;
        
        Students = studentRepository;
        Enrollments = enrollmentRepository;
        Courses = courseRepository;
    }

    public IStudentRepository Students { get; }
    public IEnrollmentRepository Enrollments { get; }
    public ICourseRepository Courses { get; }
    
    public async Task CommitAsync() => await _context.SaveChangesAsync();
}