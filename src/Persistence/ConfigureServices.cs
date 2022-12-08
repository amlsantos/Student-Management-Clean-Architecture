using Application.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Courses;
using Persistence.Database;
using Persistence.Enrollments;
using Persistence.Students;

namespace Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IEnrollmentRepository,EnrollmentRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();

        return services;
    }
}