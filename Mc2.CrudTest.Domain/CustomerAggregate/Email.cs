using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mc2.CrudTest.Domain.CustomerAggregate;

public struct Email
{
    private const string EmailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

    public string Address { get; private set; }

    private Email(string address)
    {
        Address = address;
    }

    public static Email Create(string address)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidEmailException($"Empty address is not valid");

        // Better to use "Source Generated RegEx", but this simple check is enough for now
        if (!Regex.IsMatch(address, EmailRegex))
            throw new InvalidEmailException($"Email address '{address}' is not valid");

        return new Email(address);
    }

    public static bool operator ==(Email left, Email right)
    {
        return left.Address == right.Address;
    }

    public static bool operator !=(Email left, Email right)
    {
        return left.Address != right.Address;
    }

    public override bool Equals(object obj)
    {
        return obj is Email email &&
               Address == email.Address;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Address);
    }
}
