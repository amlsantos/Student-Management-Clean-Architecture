using System.Text.Json.Serialization;
using Api.Middleware;
using Api.Utils;
using Application.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Repositories;

namespace Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;
        ConfigureServices(services);
        ConfigureDi(services);
        ConfigureMediatr(services);
        
        var app = builder.Build();
        RunMigrations(app);
        ConfigureApp(app);
        
        app.Run();
    }
    
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<StudentDbContext>();
        services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => options.CustomSchemaIds(type => type.ToString()));
    }

    private static void ConfigureDi(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IEnrollmentRepository,EnrollmentRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
    }

    private static void ConfigureMediatr(IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddMediatR(assemblies);
        services.AddFluentValidation(assemblies);
    }

    private static void RunMigrations(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<StudentDbContext>();

        context.Database.Migrate();
    }
    
    private static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}