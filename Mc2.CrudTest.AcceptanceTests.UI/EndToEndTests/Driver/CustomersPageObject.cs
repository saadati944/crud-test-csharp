using Mc2.CrudTest.Api.Models;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.UI.EndToEndTests.Driver;

public class CustomersPageObject
{
    private const string Path = "http://localhost:5015/Customers";

    private IBrowser _browser;
    private IPage _page;


    public CustomersPageObject(IBrowser browser)
    {
        _browser = browser;
    }

    public async Task NavigateToPageAsync()
    {
        _page = await _browser.NewPageAsync();
        await _page.GotoAsync(Path);
    }

    public async Task ClickCreateCustomerButton()
    {
        await _page.ClickAsync("#BtnCreateCustomer");
    }

    public Task ClickUpdateCustomerButton()
        => ClickCreateCustomerButton();

    internal async Task FillCustomerForm(CreateCustomerRequest customer)
    {
        await _page.FillAsync("#firstName", customer.FirstName);
        await _page.FillAsync("#lastName", customer.LastName);
        await _page.TypeAsync("#dateOfBirth", customer.DateOfBirth.ToString("MM/dd/yyyy"));
        await _page.FillAsync("#email", customer.Email);
        await _page.FillAsync("#phoneNumber", customer.PhoneNumber);
        await _page.FillAsync("#bankAccountNumber", customer.BankAccountNumber);
    }

    internal async Task<int> GetRecordsCount()
    {
        await _page.ReloadAsync();
        var tableBody = await _page.QuerySelectorAllAsync("#customersTableBody");
        return tableBody.Count;
    }

    internal async Task<int> GetRecordsCount(List<CreateCustomerRequest> expectedCustomers)
    {
        await _page.ReloadAsync();
        var tableBody = await _page.QuerySelectorAllAsync("#customersTableBody");
        int count = 0;
        foreach(var el in tableBody)
        {
            var innerHtml = await el.InnerHTMLAsync();
            foreach(var c in expectedCustomers)
            {
                if (innerHtml.Contains(c.FirstName.ToLower())
                    && innerHtml.Contains(c.LastName.ToLower())
                    && innerHtml.Contains(c.Email.ToLower())
                    && innerHtml.Contains(c.PhoneNumber.ToLower())
                    && innerHtml.Contains(c.BankAccountNumber.ToUpper())
                    && innerHtml.Contains(c.DateOfBirth.ToString("M/d/yyyy")))
                    count++;
            }
        }
        return count;
    }

    public async Task<bool> HaveNotification(string errorMessage)
    {
        return (await _page.InnerHTMLAsync("#Notifs")).Contains(errorMessage);
    }

    public async Task ClickEditForCustomerByEmail(string email)
    {
        await _page.Locator($"tr:has-text(\"{email}\")").First.Locator("button").First.ClickAsync();
    }

    public async Task ClickDeleteForCustomerByEmail(string email)
    {
        await _page.Locator($"tr:has-text(\"{email}\")").First.Locator("button").Last.ClickAsync();
    }
}
