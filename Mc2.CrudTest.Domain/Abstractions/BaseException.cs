namespace Mc2.CrudTest.Domain.Abstractions;

public abstract class BaseException : Exception
{
    public BaseException()
    {
    }

    public virtual int ErrorCode { get; } = 300;
    public virtual string ErrorMessage { get; } = "Invalid operation";
}
