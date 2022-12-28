namespace Mc2.CrudTest.Application.Exceptions;

public class EmailIsNotUniqueException : BaseException
{
    public EmailIsNotUniqueException(string message) : base(message)
    {
    }
}
