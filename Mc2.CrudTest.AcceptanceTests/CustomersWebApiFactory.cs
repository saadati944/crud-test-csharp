using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Mc2.CrudTest.Api;
using Mc2.CrudTest.Infrastructure;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests;

public class CustomersWebApiFactory : WebApplicationFactory<IApiMarker>, IAsyncLifetime
{
    private readonly TestcontainerDatabase _dbContainer =
        new TestcontainersBuilder<MsSqlTestcontainer>()
            .WithDatabase(new MsSqlTestcontainerConfiguration()
            {
                Password = "!@QW34ertyui",
                Database = $"crud_test_database_{Guid.NewGuid()}"
            })
            .WithImage("mcr.microsoft.com/mssql/server:2019-latest")
            .WithName($"crud_test_database_{Guid.NewGuid()}")
            .WithEnvironment("TrustServerCertificate", "True")
            .WithEnvironment("Encrypt", "False")
            .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureServices(services =>
        {
            var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(DbContextOptions<CrudTestsContext>));
            if (descriptor is not null)
                services.Remove(descriptor);

            services.AddDbContext<CrudTestsContext>(options => options.UseSqlServer($"{_dbContainer.ConnectionString}TrustServerCertificate=true;"));
        });
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        await Services.CreateScope().ServiceProvider.GetRequiredService<CrudTestsContext>().Database.EnsureCreatedAsync();
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }
}
