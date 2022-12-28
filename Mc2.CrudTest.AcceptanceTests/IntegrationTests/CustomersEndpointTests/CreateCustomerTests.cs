using Mc2.CrudTest.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.IntegrationTests.CustomerTests;

public class CreateCustomerTests : IClassFixture<CustomersWebApiFactory>
{
    private HttpClient _client;

    public CreateCustomerTests(CustomersWebApiFactory webApp)
    {
        _client = webApp.CreateClient();
    }

    [Fact]
    public async Task Create_customer_With_valid_date_Creates_a_customer()
    {
        // Arrange
        var customer = new CreateCustomerRequest(
            "customerName123",
            "customerLastName123",
            DateTime.Parse("2020-12-27T16:38:30.388"),
            "+101010101",
            "customer_123@gnirts",
            "1234-5678-9012-3456"
        );

        // Act
        var response = await _client.PostAsJsonAsync($"Customers", customer);
        var result = await response.Content.ReadFromJsonAsync<CustomerResponse>();

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.Equal(customer.FirstName, result.FirstName);
        Assert.Equal(customer.LastName, result.LastName);
        Assert.Equal(customer.DateOfBirth, result.DateOfBirth);
        Assert.Equal(customer.PhoneNumber, result.PhoneNumber);
        Assert.Equal(customer.EmailAddress, result.EmailAddress);
        Assert.Equal(customer.BankAccountNumber, result.BankAccountNumber);
    }


    [Theory]
    [InlineData("1234 1234 1234 1234")]
    [InlineData("1234567890")]
    public async Task Create_customer_With_invalid_bank_account_number_Returns_badrequest(string invalidAccountNumber)
    {
        // Arrange
        var customer = new CreateCustomerRequest(
            "customerName123",
            "customerLastName123",
            DateTime.Parse("2020-12-27T16:38:30.388"),
            "+101010101",
            "customer_123@gnirts",
            invalidAccountNumber
        );

        // Act
        var response = await _client.PostAsJsonAsync($"Customers", customer);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
