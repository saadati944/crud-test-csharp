using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Application;

public static class ServiceRegistry
{
    public static void RegisterMediatR(this IServiceCollection services)
    {
        services.AddMediatR(System.Reflection.Assembly.GetExecutingAssembly());
    }
}
