using Mc2.CrudTest.Domain.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.UnitTests.CustomerTests;

public class EmailTests
{
    [Theory]
    [InlineData("saadati944@gmail.com")]
    [InlineData("sampleEmail@EmailServer")]
    public void Create_With_a_valid_Email_Creates_a_new_instance(string validEmail)
    {
        // Act
        var mail = Email.Create(validEmail);

        // Assert
        Assert.Equal(validEmail, mail.Address);
    }

    [Theory]
    [InlineData("somthing @ somewhere ")] // use spaces
    [InlineData("asdf.com")] // without @
    [InlineData("")] // empty
    [InlineData(null)] // null
    public void Create_With_an_invalid_Email_Throws_InvalidEmailException(string invalidEmail)
    {
        // Act
        var sut = () => { Email.Create(invalidEmail); };

        // Assert
        Assert.Throws<InvalidEmailException>(sut);
    }
}