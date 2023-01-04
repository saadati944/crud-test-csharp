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
        return new PhoneNumber(num);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}
