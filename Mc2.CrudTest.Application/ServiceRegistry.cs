using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application;

public static class ServiceRegistry
{
    public static void RegisterMediatR(this IServiceCollection services)
    {
        services.AddMediatR(System.Reflection.Assembly.GetExecutingAssembly());
    }
}
