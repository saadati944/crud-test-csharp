using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Domain.CustomerAggregate;

public partial class PhoneNumber : ValueObject
{
    public ulong Number { get; init; }
    public string NumberAsString => "+" + Number.ToString();

    private PhoneNumber()
    {
    }

    private PhoneNumber(string number)
    {
        Number = ulong.Parse(number[1..]);
    }

    public static PhoneNumber Create(string number)
    {
        if (string.IsNullOrEmpty(number))
            throw new InvalidPhoneNumberException($"Empty number is not valid");

        if (number.Length is < 7 or > 15)
            throw new InvalidPhoneNumberException($"The number '{number}' does not have correct length");

        if(number.Any(c => c != '+' && !char.IsDigit(c)))
            throw new InvalidPhoneNumberException($"The number '{number}' contains non digit characters");

        if (!IsPhoneNumberValid().IsMatch(number))
            throw new InvalidPhoneNumberException($"Phone number '{number}' is not valid");

        return new PhoneNumber(number);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }

    [GeneratedRegex("\\+(9[976]\\d|8[987530]\\d|6[987]\\d|5[90]\\d|42\\d|3[875]\\d|2[98654321]\\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\\d{1,14}$")]
    private static partial Regex IsPhoneNumberValid();
}
