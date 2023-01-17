using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Mc2.CrudTest.Blazor;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var app = CreateApp(args);
        await app.RunAsync();
    }

    public static WebAssemblyHost CreateApp(string[] args, HttpClient alternativeClient = null)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => alternativeClient ?? new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiProjectURL"]) });

        var app = builder.Build();
        return app;
    }
}