using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerAggregate;

public struct PhoneNumber
{
    private const string PhoneNumberRegex = @"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$";

    public char[] Digits { get; private set; }
    public string Number => new string(Digits);

    private PhoneNumber(char[] digits)
    {
        Digits = digits;
    }

    public static PhoneNumber Create(string number)
    {
        if (string.IsNullOrEmpty(number))
            throw new InvalidPhoneNumberException($"Empty number is not valid");

        if (number.Length is < 7 or > 15)
            throw new InvalidPhoneNumberException($"The number '{number}' does not have correct length");

        if (!Regex.IsMatch(number, PhoneNumberRegex))
            throw new InvalidPhoneNumberException($"Phone number '{number}' is not valid");

        return new PhoneNumber(number.ToArray());
    }

    public static bool operator == (PhoneNumber left, PhoneNumber right)
    {
        return left.Equals(right);
    }

    public static bool operator != (PhoneNumber left, PhoneNumber right)
    {
        return !left.Equals(right);
    }

    public override bool Equals(object obj)
    {
        return obj is PhoneNumber number &&
               EqualityComparer<char[]>.Default.Equals(Digits, number.Digits);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Digits);
    }
}
