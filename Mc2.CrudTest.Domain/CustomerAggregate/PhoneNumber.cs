namespace Mc2.CrudTest.Domain.CustomerAggregate;

public class PhoneNumber : ValueObject
{
    public ulong Number { get; init; }
    public string NumberAsString => "+" + Number.ToString();

    private PhoneNumber()
    {
    }

    private PhoneNumber(ulong number)
    {
        Number = number;
    }

    public static PhoneNumber Create(string number, IPhoneNumberParser numberParser)
    {
        var num = numberParser.Parse(number);

        //if (string.IsNullOrEmpty(number))
        //    throw new InvalidPhoneNumberException($"Empty number is not valid");

        //if (number.Length is < 7 or > 15)
        //    throw new InvalidPhoneNumberException($"The number '{number}' does not have correct length");

        //if(number.Any(c => c != '+' && !char.IsDigit(c)))
        //    throw new InvalidPhoneNumberException($"The number '{number}' contains non digit characters");

        //if (!IsPhoneNumberValid().IsMatch(number))
        //    throw new InvalidPhoneNumberException($"Phone number '{number}' is not valid");

        return new PhoneNumber(num);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}
