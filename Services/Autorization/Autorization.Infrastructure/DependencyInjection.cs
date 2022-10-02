using Authorization.Infrastructure.Abstractions;
using Authorization.Infrastructure.Context;
using Authorization.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authorization.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UserDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("UserDbConnectionString")));
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
