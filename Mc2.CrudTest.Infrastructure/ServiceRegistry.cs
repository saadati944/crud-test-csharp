using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure;

public static class ServiceRegistry
{
    public static void RegisterDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CrudTestsContext>(options => options.UseSqlServer(connectionString));
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}
