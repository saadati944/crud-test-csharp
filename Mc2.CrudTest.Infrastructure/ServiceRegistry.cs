using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
}
