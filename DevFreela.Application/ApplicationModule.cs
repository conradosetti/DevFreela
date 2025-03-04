using DevFreela.Application.Models;
using DevFreela.Application.Projects.Commands.InsertProject;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers()
            .AddValidators();
        return services;
    }
    

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());
        services
            .AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>,
                ValidateInsertProjectCommandBehavior>();
        
        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining<InsertProjectCommand>();
        
        return services;
    }
}