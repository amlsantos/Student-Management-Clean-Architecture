using Application.Interfaces.Persistence;

namespace Persistence.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly SchoolDbContext _context;

    public UnitOfWork(SchoolDbContext context, IStudentRepository studentRepository, IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository)
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