namespace Mc2.CrudTest.Domain.Abstractions.Services;

public interface IPhoneNumberParser
{
    // I treated GooglePhoneLib as a parser rather than a validator, so I named it parser not validator.
    ulong Parse(string number);
}
