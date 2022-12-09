using System.Text.Json.Serialization;
using Api.Middlewares;
using Application.Extensions;
using Infrastructure.Extensions;
using Persistence.Extensions;

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
        services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => options.CustomSchemaIds(type => type.ToString()));
        
        services.AddApplication();
        services.AddPersistence();
        services.AddInfrastructure();
    }

    private static void RunMigrations(WebApplication app) => app.RunMigrations();

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