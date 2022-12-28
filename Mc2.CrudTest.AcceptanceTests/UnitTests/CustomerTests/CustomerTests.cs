using Mc2.CrudTest.Domain.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        var phoneNumber = "+989142345446";
        var emailAddress = "ali@gmail.com";
        var bankAccountNumber = "13457890";

        // Act
        var customer = Customer.Create(firstName, lastName, birthDate, phoneNumber, emailAddress, bankAccountNumber);

        // Assert
        Assert.Equal(firstName, customer.Firstname);
        Assert.Equal(lastName, customer.Lastname);
        Assert.Equal(birthDate, customer.DateOfBirth);
        Assert.Equal(phoneNumber, customer.PhoneNumber.NumberString);
        Assert.Equal(emailAddress, customer.Email.Address);
        Assert.Equal(bankAccountNumber, customer.BankAccountNumber);
    }
}
