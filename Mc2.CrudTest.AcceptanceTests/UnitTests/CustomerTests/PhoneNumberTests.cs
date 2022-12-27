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
    public void Create_With_a_valid_phone_number_Creates_a_new_instance(string validNumber)
    {
        // Act
        var phone = PhoneNumber.Create(validNumber);

        // Assert
        Assert.Equal(validNumber, phone.Digits);
        Assert.Equal(validNumber, phone.Number);
    }

    [Theory]
    [InlineData("+54 234 432 5436")] // use spaces
    [InlineData("+2223443254364444")] // long number
    [InlineData("asdf")] // bad format
    [InlineData("")] // empty
    [InlineData(null)] // null
    public void Create_With_an_invalid_phone_number_Throws_InvalidPhoneNumberException(string invalidNumber)
    {
        // Act
        var sut = () => { PhoneNumber.Create(invalidNumber); };

        // Assert
        Assert.Throws<InvalidPhoneNumberException>(sut);
    }
}
