using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerAggregate;

public class InvalidEmailException : Exception
{
    public InvalidEmailException(string message) : base(message)
    {
    }
}

public class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException(string message) : base(message)
    {
    }
}

public class InvalidFirstNameException : Exception
{
    public InvalidFirstNameException(string message) : base(message)
    {
    }
}

public class InvalidLastNameException : Exception
{
    public InvalidLastNameException(string message) : base(message)
    {
    }
}

public class InvalidBankAccountNumberException : Exception
{
    public InvalidBankAccountNumberException(string message) : base(message)
    {
    }
}
