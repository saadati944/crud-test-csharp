using Mc2.CrudTest.Domain.Abstractions;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
