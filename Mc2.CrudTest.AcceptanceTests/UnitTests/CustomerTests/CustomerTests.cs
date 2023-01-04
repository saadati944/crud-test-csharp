using Mc2.CrudTest.Domain.CustomerAggregate;
using Mc2.CrudTest.Infrastructure.Service;
using System;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.UnitTests.CustomerTests;

public class CustomerTests
{
    // Due to the tight deadline, it is enough to only validate the happy path
    // but in production, the business related validations must be checked.
    [Fact]
    public void Create_Creates_new_customer_instance_With_valid_inputs()
    {
        // Arrange
        var firstName = "some first name";
        var lastName = "some last name";
        var birthDate = new DateTime(2000, 05, 06);
        var phoneNumber = "+98 914 234 5446";
        var parsedPhoneNumber = "+989142345446";
        var emailAddress = "ali@gmail.com";
        var bankAccountNumber = "4325-2341-1234-4321";
        var numberParser = new PhoneNumberParser();

        // Act
        var customer = Customer.Create(firstName, lastName, birthDate, phoneNumber, emailAddress, bankAccountNumber, numberParser);

        // Assert
        Assert.Equal(firstName.ToLower(), customer.Firstname);
        Assert.Equal(lastName.ToLower(), customer.Lastname);
        Assert.Equal(birthDate, customer.DateOfBirth);
        Assert.Equal(parsedPhoneNumber, customer.PhoneNumber.NumberAsString);
        Assert.Equal(emailAddress.ToLower(), customer.Email.Address);
        Assert.Equal(bankAccountNumber, customer.BankAccountNumber);
    }
}
