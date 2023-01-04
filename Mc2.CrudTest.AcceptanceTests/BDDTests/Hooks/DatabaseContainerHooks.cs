using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.BDDTests.Hooks;

[Binding]
public class DatabaseContainerHooks
{
    private CustomersWebApiFactory _customersWebApiFactory;
    private IObjectContainer _objectContainer;

    public DatabaseContainerHooks(IObjectContainer container)
    {
        _objectContainer = container;
    }

    [BeforeScenario]
    public async Task InitializeNewDatabaseContainer()
    {
        _customersWebApiFactory = new CustomersWebApiFactory();
        await _customersWebApiFactory.InitializeAsync();
        _objectContainer.RegisterInstanceAs(_customersWebApiFactory.CreateClient());
    }

    [AfterScenario]
    public async Task DisposeDatabaseContainer()
    {
        await _customersWebApiFactory.DisposeAsync();
    }
}
