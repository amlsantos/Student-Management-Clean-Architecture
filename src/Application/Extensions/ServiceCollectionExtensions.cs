using Application.Behaviours;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RetryBehaviour<,>));

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        
        services.AddMediatR(assemblies);
        services.AddFluentValidation(assemblies);

        return services;
    }
}