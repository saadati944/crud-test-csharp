using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Mc2.CrudTest.Api;
using Mc2.CrudTest.Blazor;
using Mc2.CrudTest.Infrastructure;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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

public class WebApiFactory : WebApplicationFactory<IApiMarker>, IAsyncLifetime
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

public class BlazorUIFactory // : WebApplicationFactory<IUIMarker>
{
    private Uri _apiUri;
    private WebAssemblyHost _app;

    public BlazorUIFactory(Uri apiUri)
    {
        _apiUri = apiUri;
    }

    //protected void ConfigureWebHost(IWebHostBuilder builder)
    //{
    //    base.ConfigureWebHost(builder);

    //    builder.ConfigureServices(services =>
    //    {
    //        var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(HttpClient));
    //        if (descriptor is not null)
    //            services.Remove(descriptor);

    //        // services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiProjectURL"]) });
    //        services.AddScoped(sp => _apiClientFactory());
    //    });
    //}

    public void Initialize()
    {
        // _app = Mc2.CrudTest.Blazor.Program.CreateApp(new string[] { }, _apiUri);
        _ = _app.RunAsync();
    }

    public async Task DisposeAsync()
    {
        if(_app is not null)
            await _app.DisposeAsync();
    }
}