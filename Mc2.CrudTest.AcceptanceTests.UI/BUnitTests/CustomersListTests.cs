using Bunit;
using Mc2.CrudTest.Blazor.Components;
using Mc2.CrudTest.Blazor.Models;
using RichardSzalay.MockHttp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.UI.BUnitTests;

public class CustomersListTests
{
    [Fact]
    public void CustomersListShouldDisplayLoadingWhenEmpty()
    {
        using var ctx = new TestContext();
        var mockClient = ctx.Services.AddMockHttpClient();
        mockClient.When("/Customers").RespondJson(() => CustomerGenerator.GenerateCustomersResponse(0, 0, 0));
        var sut = ctx.RenderComponent<CustomersList>(ComponentParameterFactory.EventCallback<CustomerModel>("OnEdit", (c) => { }));

        var rows = sut.FindAll("tr");

        Assert.Equal(2, rows.Count); // table header row
        Assert.Equal("<td><em>Loading...</em></td>", rows[^1].InnerHtml); // loading row
    }

    [Fact]
    public async Task ShouldDisplayCustomersInformations()
    {
        using var ctx = new TestContext();
        var customers = CustomerGenerator.GenerateCustomersResponse(0, 5, 2);
        var mockClient = ctx.Services.AddMockHttpClient();
        mockClient.When("/Customers").RespondJson(() => customers);
        var sut = ctx.RenderComponent<CustomersList>(ComponentParameterFactory.EventCallback<CustomerModel>("OnEdit", (c) => { }));

        await Task.Delay(150);
        var rows = sut.FindAll("tr");

        Assert.Equal(3, rows.Count); // two customers including table header row
        int i = 1;
        foreach(var c in customers.Records)
        {
            Assert.Contains(c.FirstName, rows[i].InnerHtml);
            Assert.Contains(c.LastName, rows[i].InnerHtml);
            Assert.Contains(c.PhoneNumber, rows[i].InnerHtml);
            Assert.Contains(c.Email, rows[i].InnerHtml);
            Assert.Contains(c.BankAccountNumber, rows[i].InnerHtml);
            i++;
        }
    }

    [Fact]
    public async Task ShouldOnlyShow5RecordsAtAPage()
    {
        using var ctx = new TestContext();
        var mockClient = ctx.Services.AddMockHttpClient();
        mockClient.When("/Customers").RespondJson(() => CustomerGenerator.GenerateCustomersResponse(0, 5, 6));
        var sut = ctx.RenderComponent<CustomersList>(ComponentParameterFactory.EventCallback<CustomerModel>("OnEdit", (c) => { }));
        
        await Task.Delay(150);
        var pagesTitle = sut.FindAll("p")[0];

        Assert.Equal("Page 1 of 2", pagesTitle.InnerHtml.Trim());
    }

    [Fact]
    public async Task ShouldRefreshWhenOneCustomerGetsDeleted()
    {
        int callsCount = 0;
        using var ctx = new TestContext();
        var customers = CustomerGenerator.GenerateCustomersResponse(0, 5, 2);
        var mockClient = ctx.Services.AddMockHttpClient();

        mockClient.When("/Customers").RespondJson(() => {
            callsCount++;
            return customers;
        });
        
        var sut = ctx.RenderComponent<CustomersList>(ComponentParameterFactory.EventCallback<CustomerModel>("OnEdit", (c) => { }));
        
        await Task.Delay(150);
        sut.FindAll("button")[^1].Click(); // delete button on last row
        await Task.Delay(150);

        Assert.Equal(2, callsCount);
    }
}
