using System.Text.Json.Serialization;
using Api.Middlewares;
using Application.Configuration;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using Persistence.Database;

namespace Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;
        ConfigureServices(services);

        var app = builder.Build();
        RunMigrations(app);
        ConfigureApp(app);
        
        app.Run();
    }
    
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<SchoolDbContext>();
        services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => options.CustomSchemaIds(type => type.ToString()));
        
        services.AddApplication();
        services.AddPersistence();
        services.AddInfrastructure();
    }

    private static void RunMigrations(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();

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