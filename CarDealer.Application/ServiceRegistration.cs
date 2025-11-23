using System.Reflection;
using CarDealer.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealer.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
