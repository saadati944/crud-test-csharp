namespace Mc2.CrudTest.Application.Exceptions;

public class EmailIsNotUniqueException : BaseException
{
    public override int ErrorCode => 202;
    public override string ErrorMessage => "Duplicate customer by Email address";
}
