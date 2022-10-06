using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Authorization.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
