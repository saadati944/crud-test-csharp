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
            throw new InvalidEmailException();

        if (address.Length > 200)
            throw new InvalidEmailException();

        address = address.ToLower();

        if (!IsEmailValid().IsMatch(address))
            throw new InvalidEmailException();

        return new Email(address);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
    }

    [GeneratedRegex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")]
    private static partial Regex IsEmailValid();
}
