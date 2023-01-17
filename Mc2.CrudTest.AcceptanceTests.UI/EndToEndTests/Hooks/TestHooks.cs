using BoDi;
using Mc2.CrudTest.AcceptanceTests.UI.EndToEndTests.Driver;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.UI.EndToEndTests.Hooks;

[Binding]
public class TestHooks
{
    [BeforeScenario]
    public async Task BeforeEachScenario(IObjectContainer container)
    {
        //var _webApiFactory = new WebApiFactory();
        //await _webApiFactory.InitializeAsync();

        //var _webUiFactory = new BlazorUIFactory(_webApiFactory.CreateClient().BaseAddress);
        //_webUiFactory.Initialize();

        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 1000
        });
        var page = new CustomersPageObject(browser);
        container.RegisterInstanceAs(playwright);
        container.RegisterInstanceAs(browser);
        container.RegisterInstanceAs(page);

        // container.RegisterInstanceAs(_webApiFactory);
        // container.RegisterInstanceAs(_webUiFactory);
    }

    [AfterScenario]
    public async Task AfterEachScenario(IObjectContainer container)
    {
        await container.Resolve<IBrowser>().CloseAsync();
        container.Resolve<IPlaywright>().Dispose();
        // await container.Resolve<BlazorUIFactory>().DisposeAsync();
        // await container.Resolve<WebApiFactory>().DisposeAsync();
    }
}
