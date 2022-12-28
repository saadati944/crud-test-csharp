using Mc2.CrudTest.Domain.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.UnitTests.CustomerTests;

public class PhoneNumberTests
{
    [Theory]
    [InlineData("+989359435465")]
    [InlineData("+123454634232")]
    public void Create_Creates_a_new_instance_With_a_valid_phone_number(string validNumber)
    {
        // Act
        var phone = PhoneNumber.Create(validNumber);

        // Assert
        Assert.Equal(validNumber, phone.NumberString);
    }

    [Theory]
    [InlineData(null)] // null
    [InlineData("")] // empty
    [InlineData("+22234432543644434")] // long number
    [InlineData("+222")] // short number
    [InlineData("+542d344325436")] // contains non-digit chars
    [InlineData("asdf")] // bad format
    public void Create_Throws_InvalidPhoneNumberException_With_an_invalid_phone_number_Throws(string invalidNumber)
    {
        // Act
        var sut = () => { PhoneNumber.Create(invalidNumber); };

        // Assert
        Assert.Throws<InvalidPhoneNumberException>(sut);
    }
}
