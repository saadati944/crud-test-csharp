using Mc2.CrudTest.Domain.CustomerAggregate;
using Mc2.CrudTest.Infrastructure.Service;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.UnitTests.CustomerTests;

public class PhoneNumberTests
{
    [Theory]
    [InlineData("+989359435465", "+9809359435465")]
    [InlineData("+123454634232", "+1023454634232")]
    public void Create_Creates_a_new_instance_With_a_valid_phone_number(string parsableNumber, string parsedNumber)
    {
        // Arrange
        var numberParser = new PhoneNumberParser();

        // Act
        var phone = PhoneNumber.Create(parsableNumber, numberParser);

        // Assert
        Assert.Equal(parsedNumber, phone.NumberAsString);
    }

    [Theory]
    [InlineData(null)] // null
    [InlineData("")] // empty
    [InlineData("+22234432666666666666666666667777777777777777777777777434333333333333543644434")] // long number
    [InlineData("+222")] // short number
    [InlineData("+542##344325436")] // contains non-digit chars
    [InlineData("asdf")] // bad format
    public void Create_Throws_InvalidPhoneNumberException_With_an_invalid_phone_number_Throws(string invalidNumber)
    {
        // Arrange
        var numberParser = new PhoneNumberParser();

        // Act
        var sut = () => { PhoneNumber.Create(invalidNumber, numberParser); };

        // Assert
        Assert.Throws<InvalidPhoneNumberException>(sut);
    }
}
