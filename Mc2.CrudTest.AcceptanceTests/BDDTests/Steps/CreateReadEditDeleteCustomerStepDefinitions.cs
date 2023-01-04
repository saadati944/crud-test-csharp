using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mc2.CrudTest.AcceptanceTests.BDDTests.Drivers;
using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Domain.CustomerAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Mc2.CrudTest.AcceptanceTests;

[Binding]
public class CreateReadEditDeleteCustomerStepDefinitions
{
    private readonly CustomerManagementEndpointDriver _customerEndpointDriver;
    private Dictionary<string, string> _systemErrors;


    public CreateReadEditDeleteCustomerStepDefinitions(CustomerManagementEndpointDriver customerEndpointDriver)
    {
        _customerEndpointDriver = customerEndpointDriver;
    }

    [Given(@"system error codes are following")]
    public void GivenSystemErrorCodesAreFollowing(Table table)
    {
        _systemErrors = table.Rows.ToDictionary(r => r[0], r => r[1]);
    }

    [When(@"user creates a customer with following data by sending 'Create Customer Command'")]
    public async Task WhenUserCreatesACustomerWithFollowingDataBySending(Table table)
    {
        var customer = table.CreateSet<CreateCustomerRequest>().Single();
        await _customerEndpointDriver.CallCreateCustoemrEndPoint(customer);
    }

    [Then(@"user can lookup all customers and filter by below properties and get ""([^""]*)"" records")]
    public async Task ThenUserCanLookupAllCustomersAndFilterByBelowPropertiesAndGetRecords(int numberOfRecords, Table table)
    {
        var filter = table.CreateSet<CustomerFilter>().Single();
        var result = await _customerEndpointDriver.CallGetAllCustomersEndPoint(numberOfRecords, filter);
        Assert.AreEqual(numberOfRecords, result.TotalCount);
    }

    [Then(@"user must receive error code of ""([^""]*)""")]
    public void ThenUserMustReceiveErrorCodeOf(int errorCode)
    {
        Assert.AreEqual(errorCode, _customerEndpointDriver.CreateCustomerErrorCode);
    }

    [When(@"user edit customer with new data")]
    public async Task WhenUserEditCustomerWithNewData(Table table)
    {
        var customer = await _customerEndpointDriver.GetCustomer();
        var newCustomer = table.CreateSet<CreateCustomerRequest>().Single();
        await _customerEndpointDriver.CallUpdateCustomerEndPoint(customer.ID, newCustomer);
    }

    [When(@"user delete customer by Email of ""([^""]*)""")]
    public async Task WhenUserDeleteCustomerByEmailOf(string email)
    {
        var customer = await _customerEndpointDriver.GetCustomerByEmail(email);
        await _customerEndpointDriver.CallDeleteCustomerEndPoint(customer.ID);
    }

    [Then(@"user can get all records and get ""([^""]*)"" records")]
    public async Task ThenUserCanGetAllRecordsAndGetRecords(int numberOfRecords)
    {
        var result = await _customerEndpointDriver.CallGetAllCustomersEndPoint(numberOfRecords);
        Assert.AreEqual(numberOfRecords, result.TotalCount);
    }

}
