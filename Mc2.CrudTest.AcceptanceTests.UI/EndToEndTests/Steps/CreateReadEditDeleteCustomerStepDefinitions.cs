using Mc2.CrudTest.AcceptanceTests.UI.EndToEndTests.Driver;
using Mc2.CrudTest.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.UnitTestProvider;

namespace Mc2.CrudTest.AcceptanceTests.UI.EndToEndTests.Steps
{
    [Binding]
    public class CreateReadEditDeleteCustomerStepDefinitions
    {
        private CustomersPageObject _customersPage;
        private Dictionary<string, string> _systemErrors;

        public CreateReadEditDeleteCustomerStepDefinitions(CustomersPageObject customersPage)
        {
            _customersPage = customersPage;
        }

        [Given(@"system error codes are following")]
        public void GivenSystemErrorCodesAreFollowing(Table table)
        {
            _systemErrors = table.Rows.ToDictionary(r => r[0], r => r[1]);
        }

        [Given(@"Browser at customers page")]
        public async Task GivenBrowserAtCustomersPage()
        {
            await _customersPage.NavigateToPageAsync();
        }

        [When(@"user fills CreateCustomer form by following data and clicks Create button")]
        public async Task WhenUserFillsCreateCustomerFormByFollowingDataAndClicksCreateButton(Table table)
        {
            var customer = table.CreateSet<CreateCustomerRequest>().Single();
            await _customersPage.FillCustomerForm(customer);
            await _customersPage.ClickCreateCustomerButton();
        }

        [Then(@"user can look at customers list and find ""([^""]*)"" records by below properties")]
        public async Task ThenUserCanLookAtCustomersListAndFindRecordsByBelowProperties(int count, Table table)
        {
            var expectedCustomers = table.CreateSet<CreateCustomerRequest>().ToList();
            int recordsCount = await _customersPage.GetRecordsCount(expectedCustomers);
            Assert.AreEqual(count, recordsCount);
        }

        [Then(@"user must get error message of code ""([^""]*)""")]
        public async Task ThenUserMustGetErrorMessageOfCode(string errorCode)
        {
            var errorMessage = _systemErrors[errorCode];
            Assert.IsTrue(await _customersPage.HaveNotification(errorMessage));
        }

        [When(@"user clicks edit button on customers list for customer by email of ""([^""]*)""")]
        public async Task WhenUserClicksEditButtonOnCustomersListForCustomerByEmailOf(string email)
        {
            await Task.Delay(500);
            await _customersPage.ClickEditForCustomerByEmail(email);
            await Task.Delay(500);
        }

        [When(@"user fills UpdateCustomer form by following data and clicks Update button")]
        public async void WhenUserFillsUpdateCustomerFormByFollowingDataAndClicksUpdateButton(Table table)
        {
            var customer = table.CreateSet<CreateCustomerRequest>().Single();
            await _customersPage.FillCustomerForm(customer);
            await _customersPage.ClickUpdateCustomerButton();
            await Task.Delay(500);
        }

        [When(@"user clicks delete button on customers list for customer by email of ""([^""]*)""")]
        public async Task WhenUserClicksDeleteButtonOnCustomersListForCustomerByEmailOf(string email)
        {
            await _customersPage.ClickEditForCustomerByEmail(email);
        }

        [Then(@"user can get all records and get ""([^""]*)"" records")]
        public async Task ThenUserCanGetAllRecordsAndGetRecords(int count)
        {
            await _customersPage.GetRecordsCount();
        }
    }
}
