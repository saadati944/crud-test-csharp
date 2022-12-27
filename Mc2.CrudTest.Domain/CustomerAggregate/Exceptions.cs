using Mc2.CrudTest.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerAggregate;

public class InvalidEmailException : BaseException
{
    public InvalidEmailException(string message) : base(message)
    {
    }
}

public class InvalidPhoneNumberException : BaseException
{
    public InvalidPhoneNumberException(string message) : base(message)
    {
    }
}

public class InvalidFirstNameException : BaseException
{
    public InvalidFirstNameException(string message) : base(message)
    {
    }
}

public class InvalidLastNameException : BaseException
{
    public InvalidLastNameException(string message) : base(message)
    {
    }
}

public class InvalidBankAccountNumberException : BaseException
{
    public InvalidBankAccountNumberException(string message) : base(message)
    {
    }
}

public class InvalidDateOfBirthException : BaseException
{
    public InvalidDateOfBirthException(string message) : base(message)
    {
    }
}
