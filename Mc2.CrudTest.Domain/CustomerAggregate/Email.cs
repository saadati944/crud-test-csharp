namespace Mc2.CrudTest.Domain.CustomerAggregate;

public partial class Email : ValueObject
{
    public string Address { get; init; }

    private Email()
    {
    }

    private Email(string address)
    {
        Address = address;
    }


    public static Email Create(string address)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidEmailException($"Empty address is not valid");

        if (address.Length > 200)
            throw new InvalidEmailException($"The length of the address can not be more than 200 characters");

        address = address.ToLower();

        if (!IsEmailValid().IsMatch(address))
            throw new InvalidEmailException($"Email address '{address}' is not valid");

        return new Email(address);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
    }

    [GeneratedRegex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")]
    private static partial Regex IsEmailValid();
}
