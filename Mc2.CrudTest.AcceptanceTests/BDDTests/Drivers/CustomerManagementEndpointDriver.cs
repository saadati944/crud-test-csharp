using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Domain.CustomerAggregate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mc2.CrudTest.AcceptanceTests.BDDTests.Drivers;

public class CustomerManagementEndpointDriver
{
    private readonly HttpClient _client;

    public int CreateCustomerErrorCode { get; set; }

    public CustomerManagementEndpointDriver(HttpClient client)
    {
        _client = client;
    }

    public async Task CallCreateCustoemrEndPoint(CreateCustomerRequest createCustomerRequest)
    {
        var response = await _client.PostAsJsonAsync("Customers", createCustomerRequest);
        if (response.StatusCode == HttpStatusCode.Created)
            return;

        var errorResult = await response.Content.ReadFromJsonAsync<ErrorResponse>();
        CreateCustomerErrorCode = errorResult.ErrorCode;
    }

    public Task<CustomersResponse> CallGetAllCustomersEndPoint(int maximumResults)
    {
        return CallGetAllCustomersEndPoint(maximumResults, null);
    }

    public async Task<CustomersResponse> CallGetAllCustomersEndPoint(int maximumResults, CustomerFilter filter)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);

        query["Page"] = "0";
        query["PageSize"] = maximumResults.ToString();
        if (filter is not null)
        {
            if (!string.IsNullOrWhiteSpace(filter.FirstName))
                query[nameof(filter.FirstName)] = filter.FirstName;
            if (!string.IsNullOrWhiteSpace(filter.LastName))
                query[nameof(filter.LastName)] = filter.LastName;
            if (filter.DateOfBirth is not null)
                query[nameof(filter.DateOfBirth)] = filter.DateOfBirth.Value.ToShortDateString();
            if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
                query[nameof(filter.PhoneNumber)] = filter.PhoneNumber;
            if (!string.IsNullOrWhiteSpace(filter.Email))
                query[nameof(filter.Email)] = filter.Email;
            if (!string.IsNullOrWhiteSpace(filter.BankAccountNumber))
                query[nameof(filter.BankAccountNumber)] = filter.BankAccountNumber;
        }

        var response = await _client.GetAsync($"Customers?{query}");
        if(response.StatusCode == HttpStatusCode.OK)
            return await response.Content.ReadFromJsonAsync<CustomersResponse>();

        return null;
    }

    public async Task CallUpdateCustomerEndPoint(Guid id, CreateCustomerRequest newCustomer)
    {
        await _client.PutAsJsonAsync($"Customers/{id}", newCustomer);
    }

    public async Task CallDeleteCustomerEndPoint(Guid id)
    {
        await _client.DeleteAsync($"Customers/{id}");
    }

    public async Task<CustomerResponse> GetCustomerByEmail(string email)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);

        query["Page"] = 0.ToString();
        query["PageSize"] = 1.ToString();
        query["Email"] = email;
        
        string url = $"Customers?{query}";

        var response = await _client.GetAsync(url);
        return (await response.Content.ReadFromJsonAsync<CustomersResponse>()).Records.Single();
    }

    public async Task<CustomerResponse> GetCustomer()
    {
        var query = HttpUtility.ParseQueryString(string.Empty);

        query["Page"] = 0.ToString();
        query["PageSize"] = 1.ToString();
        
        string url = $"Customers?{query}";

        var response = await _client.GetAsync(url);
        return (await response.Content.ReadFromJsonAsync<CustomersResponse>()).Records.Single();
    }
}

public sealed record CustomerFilter(
    string FirstName,
    string LastName,
    DateTime? DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber);
