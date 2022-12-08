using Microsoft.EntityFrameworkCore;
using Persistence.Courses;
using Persistence.Disenrollments;
using Persistence.Enrollments;
using Persistence.Students;
using StudentManagementSystem.Entities;

namespace Persistence.Database;

public class SchoolDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Disenrollment> Disenrollments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=StudentDatabase";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
        modelBuilder.ApplyConfiguration(new DisenrollmentConfiguration());
    }
}