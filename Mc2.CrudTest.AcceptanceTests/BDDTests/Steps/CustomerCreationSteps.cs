﻿using Azure;
using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Domain.CustomerAggregate;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.BDDTests.Steps;

[Binding]
public class CustomerCreationSteps : IClassFixture<CustomersWebApiFactory>
{
    private readonly HttpClient _client;
    private List<CreateCustomerRequest> _customersInformation;
    private List<(HttpResponseMessage Response, CustomerResponse Result)> _createCustomerEndpointCallResponses;

    public CustomerCreationSteps(HttpClient client)
    {
        _client = client;
    }

    [Given(@"Following customer informations")]
    public void GivenValidCustomerInformation(Table table)
    {
        _customersInformation = new List<CreateCustomerRequest>();
        foreach (var row in table.Rows)
        {
            _customersInformation.Add(new CreateCustomerRequest(
                row[0],
                row[1],
                DateTime.Parse(row[2]),
                row[3],
                row[4],
                row[5]
            ));
        }
    }

    [When(@"Calling CreateCustomer endpoint")]
    public async Task WhenCallingCreateCustomerEndpoint()
    {
        _createCustomerEndpointCallResponses = new();
        foreach (var customer in _customersInformation)
        {
            var response = await _client.PostAsJsonAsync($"Customers", customer);
            var result = response.StatusCode == HttpStatusCode.Created
                ? await response.Content.ReadFromJsonAsync<CustomerResponse>()
                : null;

            _createCustomerEndpointCallResponses.Add(new(response, result));
        }
    }

    [Then(@"New customers should be created")]
    public void ThenNewCustomerShouldBeCreated()
    {
        for (int i = 0; i < _createCustomerEndpointCallResponses.Count; i++)
        {
            var result = _createCustomerEndpointCallResponses[i].Result;
            Assert.Equal(HttpStatusCode.Created, _createCustomerEndpointCallResponses[i].Response.StatusCode);
            Assert.Equal(_customersInformation[i].FirstName, result.FirstName);
            Assert.Equal(_customersInformation[i].LastName, result.LastName);
            Assert.Equal(_customersInformation[i].DateOfBirth, result.DateOfBirth);
            Assert.Equal(_customersInformation[i].PhoneNumber, result.PhoneNumber);
            Assert.Equal(_customersInformation[i].EmailAddress, result.EmailAddress);
            Assert.Equal(_customersInformation[i].BankAccountNumber, result.BankAccountNumber);
        }
    }

    [Then(@"Only first customer should be created")]
    public void OnlyFirstCustomerShouldBeCreated()
    {
        for (int i = 0; i < _createCustomerEndpointCallResponses.Count; i++)
        {
            var result = _createCustomerEndpointCallResponses[i].Result;
            if (i == 0)
            {
                Assert.Equal(HttpStatusCode.Created, _createCustomerEndpointCallResponses[i].Response.StatusCode);
                Assert.Equal(_customersInformation[i].FirstName, result.FirstName);
                Assert.Equal(_customersInformation[i].LastName, result.LastName);
                Assert.Equal(_customersInformation[i].DateOfBirth, result.DateOfBirth);
                Assert.Equal(_customersInformation[i].PhoneNumber, result.PhoneNumber);
                Assert.Equal(_customersInformation[i].EmailAddress, result.EmailAddress);
                Assert.Equal(_customersInformation[i].BankAccountNumber, result.BankAccountNumber);
            }
            else
            {
                Assert.Equal(HttpStatusCode.BadRequest, _createCustomerEndpointCallResponses[i].Response.StatusCode);
                Assert.Null(result);
            }
        }
    }
}