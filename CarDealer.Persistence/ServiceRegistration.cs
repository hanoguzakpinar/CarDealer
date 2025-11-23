using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Application.Interfaces.UnitOfWorks;
using CarDealer.Persistence.Context;
using CarDealer.Persistence.Repositories;
using CarDealer.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealer.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CarDealerDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Default")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}