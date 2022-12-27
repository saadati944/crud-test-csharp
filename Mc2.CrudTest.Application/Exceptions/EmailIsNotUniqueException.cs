using Mc2.CrudTest.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Exceptions;

public class EmailIsNotUniqueException : BaseException
{
    public EmailIsNotUniqueException(string message) : base(message)
    {
    }
}
